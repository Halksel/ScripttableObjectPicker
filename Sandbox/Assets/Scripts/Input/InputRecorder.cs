using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using Zenject;

namespace Sandbox
{
    /// <summary>
    /// 入力記録
    /// 同時入力への対応が終わってない
    /// </summary>
    public class InputRecorder : IDisposable, ITickable
    {
        [Serializable]
        public class InputRecord
        {
            public InputRecord(InputEventPtr ptr, InputDevice device)
            {
                id = ptr.id;
                time = _time;
                deviceId = ptr.deviceId;
                valid = ptr.valid;
                if (device.allControls[0].IsActuated())
                {
                    index = device.allControls.Skip(1).TakeWhile(ctl => !ctl.IsActuated()).Count() + 1;
                    if (ptr.type.ToString() == "STAT")
                    {
                        value = 0f;
                    }
                    else
                    {
                        value = device.allControls[index].ReadValueAsObject();
                    }
                    data = BitConverter.GetBytes((float)value);
                    Debug.Log(time);
                }
                else
                {
                    valid = false;
                }
            }
            public int id;
            public int deviceId;
            public double time;
            public int index;
            public bool valid;
            public object value;
            public byte[] data;
        }

        /// <summary>
        /// List<T> をJsonUtilityはシリアライズできないのでラッパークラス
        /// 端的にゴミ
        /// </summary>
        [Serializable]
        public class InputRecords
        {
            public List<InputRecord> records = new List<InputRecord>();
            public void Sort()
            {
                records = records.OrderBy(a => a.time).ToList();
            }
            public void Validation()
            {
                records = records.Where(r => r.valid).ToList();
            }
        }

        public InputRecorder()
        {
            InputSystem.onEvent += InputSystem_onEvent;
            _saveDirectory = Application.dataPath + $"/InputRecords/test.json";
            IsRecord = false;
        }

        public void Dispose()
        {
            InputSystem.onEvent -= InputSystem_onEvent;
        }

        private void InputSystem_onEvent(InputEventPtr ptr, InputDevice device)
        {
            if (!IsRecord) return;
            if (ptr.deviceId != 1) return;
            var record = new InputRecord(ptr, device);
            _records.records.Add(record);
            Debug.Log(record);
        }

        public void Update()
        {

        }

        public List<InputRecord> GetValidRecords()
        {
            _records.Validation();
            return _records.records;
        }

        public void SaveInputRecord(string path = "")
        {
            _records.Validation();
            _records.Sort();
            if (path == "") path = _saveDirectory;
            var json = JsonUtility.ToJson(_records, true);
            var encoding = new UTF8Encoding(true, false);
            File.WriteAllText(path, json, encoding);

            AssetDatabase.ImportAsset(path);
            var asset = AssetDatabase.LoadAssetAtPath<TextAsset>(path);
            ProjectWindowUtil.ShowCreatedAsset(asset);

            AssetDatabase.Refresh();
            IsRecord = false;
        }

        public void LoadInputRecord(string path = "")
        {
            if (path == "") path = _saveDirectory;
            var encoding = new UTF8Encoding(true, false);
            var json = File.ReadAllText(path, encoding);
            try
            {
                _records = JsonUtility.FromJson<InputRecords>(json);
                _records.records.ForEach(record =>
                {
                    record.value = BitConverter.ToSingle(record.data, 0);
                });
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void StartRecord()
        {
            _records.records.Clear();
            IsRecord = true;
            _time = 0;
        }
        public IEnumerator EmurateInput(string path)
        {
            if (_isPlayRecord)
                yield break;
            LoadInputRecord(path);
            IsRecord = false;
            _isPlayRecord = true;
            int idx = 0;
            var records = GetValidRecords();
            // 現在のScene名を取得する
            Scene loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);
            double time = 0;
            while (true)
            {
                time += Time.deltaTime;
                while (idx < records.Count() && time > records[idx].time)
                {
                    if (!records[idx].valid)
                    {
                        ++idx;
                        continue;
                    }
                    Debug.Log(records[idx].time);
                    var record = records[idx];
                    // 入力レコードによって値をセット
                    var device = InputSystem.GetDeviceById(record.deviceId);
                    using (StateEvent.From(device, out var eventPtr))
                    {
                        object value = null;
                        try
                        {
                            value = record.value;
                            if (value == null)
                            {
                                throw new ArgumentException("");
                            }

                            time = record.time;
                        }
                        catch (Exception e)
                        {
                            Debug.Log($"{e}");
                            ++idx;
                            break;
                        }
                        device.allControls[record.index].WriteValueFromObjectIntoEvent(eventPtr, value);
                        InputSystem.QueueEvent(eventPtr);
                    }
                    ++idx;
                }
                InputSystem.Update();

                if (idx >= records.Count())
                {
                    Debug.Log("End of Emulate");
                    _isPlayRecord = false;
                    yield break;
                }
                else
                {
                    yield return null;
                }
            }
        }

        public void Tick()
        {
            _time += Time.deltaTime;
        }

        private InputRecords _records = new InputRecords();
        private string _saveDirectory;
        private bool _isPlayRecord;

        public bool IsRecord { get; set; }
        private static double _time = 0;
    }
}

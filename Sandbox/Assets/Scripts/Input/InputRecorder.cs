using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using Zenject;

namespace Sandbox
{
    using Pairs = List<KeyValuePair<string, int>>;
    /// <summary>
    /// 入力記録
    /// 同時入力への対応が終わってない
    /// </summary>
    public class InputRecorder : IDisposable, ITickable
    {
        [Serializable]
        public class InputRecord
        {
            public InputRecord(InputEventPtr ptr, InputControl ctl)
            {
                id = ptr.id;
                time = Time.frameCount - _startFrame;
                Debug.Log(time);
                deviceId = ptr.deviceId;
                valid = ptr.valid;
                name = ctl.name;
                if (ptr.type.ToString() == "STAT")
                {
                    value = 0f;
                }
                else
                {
                    value = ctl.ReadValueAsObject();
                }
                data = BitConverter.GetBytes((float)value);
            }
            public int id;
            public int deviceId;
            public int time;
            public string name;
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
            public Pairs lastValues = new Pairs();
            public void Sort()
            {
                records = records.OrderBy(a => a.time).ToList();
            }
            public bool CheckValues(Dictionary<string, int> values)
            {
                return lastValues.All(kvp => values[kvp.Key] == kvp.Value);
            }
            public void SaveValues(Dictionary<string, int> values)
            {
                lastValues.AddRange(values);
            }
            public void ResetValues()
            {
                lastValues.Clear();
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
            if (ptr.deviceId != 1 || !ptr.valid) return;
            foreach (var ctl in device.allControls.Skip(1))
            {
                if (ctl.IsActuated())
                {
                    var record = new InputRecord(ptr, ctl);
                    _records.records.Add(record);
                }
            }
        }

        public List<InputRecord> GetRecords()
        {
            return _records.records;
        }

        public void SaveInputRecord(string path = "")
        {
            _records.Sort();
            _records.SaveValues(InputRecorderLastValueAttribute.GetLastValuesReflection(player));
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
            catch (Exception e)
            {
                throw e;
            }
        }


        public void StartRecord()
        {
            _records.records.Clear();
            InputRecorderLastValueAttribute.GetLastValuesReflection(player);
            IsRecord = true;
            _startFrame = 0;
        }
        public IEnumerator EmurateInput(string path)
        {
            if (_isPlayRecord)
                yield break;
            LoadInputRecord(path);
            IsRecord = false;
            _isPlayRecord = true;
            int idx = 0;
            var records = GetRecords();
            // 現在のScene名を取得する
            Scene loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);
            var mode = InputSystem.settings.updateMode;
            InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsManually;
            _startFrame = Time.frameCount;
            while (true)
            {
                while (Time.frameCount >= _startFrame + records[idx].time)
                {
                    var id = records[idx].deviceId;
                    // 入力レコードによって値をセット
                    var device = InputSystem.GetDeviceById(id);
                    using (StateEvent.From(device, out var eventPtr))
                    {
                        while (idx < records.Count() && records[idx].time + _startFrame <= Time.frameCount && records[idx].deviceId == id)
                        {
                            var record = records[idx];
                            object value = null;
                            try
                            {
                                value = record.value;
                                if (value == null)
                                {
                                    throw new ArgumentException("");
                                }
                                ++idx;
                            }
                            catch (Exception e)
                            {
                                Debug.Log($"{e}");
                                ++idx;
                                break;
                            }
                            device.GetChildControl(record.name).WriteValueFromObjectIntoEvent(eventPtr, value);
                            InputSystem.QueueEvent(eventPtr);
                            Debug.Log(Time.frameCount - _startFrame);
                            InputSystem.Update();
                        }
                    }

                    if (idx >= records.Count())
                    {
                        Debug.Log("End of Emulate");
                        _isPlayRecord = false;
                        InputSystem.settings.updateMode = mode;
                        bool result = _records.CheckValues(InputRecorderLastValueAttribute.GetLastValuesReflection(player));
                        Debug.Log($"CheckValues: {result}");
                        yield break;
                    }
                    else
                    {
                        break;
                    }
                }
                yield return null;
            }
        }

        // Update
        public void Tick()
        {
        }

        private InputRecords _records = new InputRecords();
        private string _saveDirectory;
        private bool _isPlayRecord;

        public bool IsRecord { get; set; }
        private static int _startFrame = 0;
        private Player _player;
        private Player player
        {
            get
            {
                if (_player == null)
                {
                    _player = UnityEngine.Transform.FindObjectOfType<Player>();
                }
                return _player;
            }
            set
            {
                _player = value;
            }
        }
    }
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class InputRecorderLastValueAttribute : Attribute
    {
        static Type type = typeof(InputRecorderLastValueAttribute);
        private string _name;
        public InputRecorderLastValueAttribute(string name) { _name = name; }
        public string Name { get { return _name; } }

        public static Dictionary<string, int> GetLastValuesReflection<T>(T obj)
        {
            var result = new Dictionary<string, int>();
            foreach (FieldInfo fieldInfo in typeof(T).GetFields())
            {
                var attributes = Attribute.GetCustomAttributes(
                    fieldInfo, type) as InputRecorderLastValueAttribute[];

                foreach (var attribute in attributes)
                {
                    //属性が定義されたプロパティだけを参照するため、fixedAttrがnullなら処理の対象外
                    if (attribute != null)
                    {
                        Debug.Log(fieldInfo.GetValue(obj));
                        result[attribute.Name] = fieldInfo.GetValue(obj as object).GetHashCode();
                    }
                }
            }
            return result;
        }
    }
}

using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using System;
using System.IO;
using System.Text;
using UnityEditor;

namespace Sandbox {
    using Context = InputAction.CallbackContext;
    /// <summary>
    /// 入力記録
    /// 同時入力への対応が終わってない
    /// </summary>
    public class InputRecorder : SingletonMonoBehaviour<InputRecorder>
    {
        [Serializable]
        public class InputRecord
        {
            public unsafe InputRecord(InputEventPtr ptr, InputDevice device)
            {
                id = ptr.id;
                time = ptr.time;
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
        
        public override bool Setup()
        {
            InputSystem.onEvent += InputSystem_onEvent;
            IsRecord = true;
            return true;
        }

        private void OnDestroy()
        {
            InputSystem.onEvent -= InputSystem_onEvent;
        }

        unsafe private void InputSystem_onEvent(InputEventPtr ptr, InputDevice device)
        {
            if (!IsRecord) return;
            if (ptr.deviceId != 1) return;
            var record = new InputRecord(ptr, device);
            _records.records.Add(record);
            Debug.Log(record);
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
            var json = JsonUtility.ToJson(_records,true);
            var encoding = new UTF8Encoding(true, false);
            var pathName = Application.dataPath + $"/{path}/test.json";
            File.WriteAllText(pathName, json, encoding);

            AssetDatabase.ImportAsset(pathName);
            var asset = AssetDatabase.LoadAssetAtPath<TextAsset>(pathName);
            ProjectWindowUtil.ShowCreatedAsset(asset);

            AssetDatabase.Refresh();
        }

        public void LoadInputRecord(string path = "")
        {
            if (path == "") path = _saveDirectory;
            var encoding = new UTF8Encoding(true, false);
            var pathName = Application.dataPath + $"/{path}/test.json";
            var json = File.ReadAllText(pathName, encoding);
            _records = JsonUtility.FromJson<InputRecords>(json);
            _records.records.ForEach(record =>
            {
                record.value = BitConverter.ToSingle( record.data, 0);
            });
        }

        private InputRecords _records = new InputRecords();

        [SerializeField]
        private bool _isRecord;
        [SerializeField]
        private string _saveDirectory = "InputRecords";

        public bool IsRecord { get => _isRecord; set => _isRecord = value; }
    }
}

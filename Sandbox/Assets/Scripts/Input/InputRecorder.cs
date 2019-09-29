using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using System;
using System.Runtime.Serialization;

namespace Sandbox {
    using Context = InputAction.CallbackContext;
    public class InputRecorder : SingletonMonoBehaviour<InputRecorder>
    {
        [Serializable]
        public class InputRecord
        {
            public InputRecord(InputEventPtr ptr)
            {
                fourCC = ptr.type.ToString();
                time = ptr.time;
                sizeInBytes = (int)ptr.sizeInBytes;
                deviceId = ptr.deviceId;
            }

            unsafe public InputEventPtr CreateInstance()
            {
                var ptr = new InputEvent(new UnityEngine.InputSystem.Utilities.FourCC(fourCC),sizeInBytes, deviceId, time);
                return new InputEventPtr(&ptr);
            }
            public string fourCC;
            public int deviceId;
            public double time;
            public int sizeInBytes;
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
        }
        
        public override bool Setup()
        {
            InputSystem.onEvent += InputSystem_onEvent;
            _isRecord = true;
            return true;
        }

        private void OnDestroy()
        {
            InputSystem.onEvent -= InputSystem_onEvent;
        }

        unsafe private void InputSystem_onEvent(InputEventPtr ptr, InputDevice device)
        {
            if (!_isRecord) return;
            if (ptr.deviceId == 1)
            {
                var record = new InputRecord(ptr);
                _records.records.Add(record);
            }
        }

        public IEnumerator<InputRecord> GetRecords()
        {
            return _records.records.GetEnumerator();
        }

        public void GenerateInputRecords()
        {
            _records.Sort();
            var json = JsonUtility.ToJson(_records);
            Debug.Log(json);
        }

        private bool _isRecord;
        private InputRecords _records = new InputRecords();
    }
}

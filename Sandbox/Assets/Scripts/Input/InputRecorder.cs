using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using System;
using System.Runtime.Serialization;
using UnityEngine.InputSystem.Controls;

namespace Sandbox {
    using Context = InputAction.CallbackContext;
    public class InputRecorder : SingletonMonoBehaviour<InputRecorder>
    {
        [Serializable]
        public class InputRecord
        {
            public unsafe InputRecord(InputEventPtr ptr, InputDevice device)
            {
                fourCC = ptr.type.ToString();
                id = ptr.id;
                time = ptr.time;
                sizeInBytes = (int)ptr.sizeInBytes;
                format = device.stateBlock.format.ToString();
                deviceId = ptr.deviceId;
                valid = ptr.valid;
                if (device.allControls[0].IsActuated())
                {
                    index = device.allControls.Skip(1).TakeWhile(ctl => !ctl.IsActuated()).Count() + 1;
                    type = device.allControls[index].valueType;
                    value = device.allControls[index].ReadValueAsObject();
                    Debug.Log(time);
                    //valid = ptr.IsA<DeltaStateEvent>() || ptr.IsA<StateEvent>();
                }
                else
                {
                    index = 0;
                    type = device.allControls[index].valueType;
                    value = 0f;
                    valid = false;
                }
                //validation();
            }

            unsafe public InputEventPtr CreatePtr()
            {
                var inputEvent = new InputEvent(new UnityEngine.InputSystem.Utilities.FourCC(fourCC),sizeInBytes, deviceId, time);
                var ptr = new InputEventPtr(&inputEvent);
                return ptr;
            }

            private void validation()
            {
                if(fourCC == null)
                {
                    valid = false;
                }
                else if(deviceId == 0)
                {
                    valid = false;
                }
                else
                {
                    valid = true;
                }
            }
            public string fourCC;
            public string format;
            public int id;
            public Type type;
            public int deviceId;
            public double time;
            public int sizeInBytes;
            public int index;
            public bool valid;
            public object value;
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
            if (ptr.deviceId == 1)
            {
                var record = new InputRecord(ptr, device);
                _records.records.Add(record);
                Debug.Log(record);
            }
        }

        public List<InputRecord> GetValidRecords()
        {
            _records.records = _records.records.Where(r => r.valid).ToList();
            return _records.records;
        }

        public void GenerateInputRecords()
        {
            _records.Sort();
            var json = JsonUtility.ToJson(_records);
            Debug.Log(json);
        }

        private InputRecords _records = new InputRecords();

        public bool IsRecord { get; set; }
    }
}

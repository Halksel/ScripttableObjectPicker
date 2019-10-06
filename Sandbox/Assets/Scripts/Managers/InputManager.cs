using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

namespace Sandbox
{
    using Record = InputRecorder.InputRecord;
    public class InputManager : SingletonMonoBehaviour<InputManager>, DebugInput.IDebugActions
    {
        public enum InputType
        {
            Debug,
            Basis,
            UI,
        }

        struct InputProxy
        {
            public InputProxy(IInputActionCollection input, int priority)
            {
                this.input = input;
                this.priority = priority;
                this.input.Enable();
            }
            public IInputActionCollection input;
            public int priority;
        }

        private IInputActionCollection constructInput(InputType inputType)
        {
            switch (inputType)
            {
                case InputType.Debug:
                    return new DebugInput();
                case InputType.Basis:
                    return new BasisInput();
                case InputType.UI:
                    return new UIInput();
                default:
                    return null;
            }
        }

        public override bool Setup()
        {
            var input = new DebugInput();
            input.Enable();
            input.Debug.SetCallbacks(this);
            _inputProxies.Add(new InputProxy(input, -1));
            return true;
        }

        public IInputActionCollection CreateCurrentPriorityProxy(InputType inputType)
        {
            var input = constructInput(inputType);
            if(inputType == InputType.Debug)
            {
                _inputProxies.Add(new InputProxy(input, -1));
            }
            else
            {
                _inputProxies.Add(new InputProxy(input, _currentInputPriority));
            }
            switchInputPriority();
            return input;

        }

        public IInputActionCollection CreateTopPriorityProxy(InputType inputType)
        {
            ++_currentInputPriority;
            return CreateCurrentPriorityProxy(inputType);
        }

        public void DeleteInputProxy(IInputActionCollection input)
        {
            var proxy = _inputProxies.Where(p => p.input == input).Single();
            proxy.input.Disable();
            _inputProxies.Remove(proxy);
            _currentInputPriority = _inputProxies.OrderBy(p => p.priority).Last().priority;
            switchInputPriority();
        }

        private void switchInputPriority()
        {
            foreach(var proxy in _inputProxies ){
                if(proxy.priority == -1 || proxy.priority == _currentInputPriority)
                {
                    proxy.input.Enable();
                }
                else
                {
                    proxy.input.Disable();
                }
            }
        }

        IEnumerator EmurateInput()
        {
            int idx = 0;
            _records = InputRecorder.Instance.GetValidRecords();
            while(true)
            {
                _time += Time.deltaTime;
                while (idx < _records.Count() && _time > _records[idx].time)
                {
                    if (!_records[idx].valid)
                    {
                        ++idx;
                        continue;
                    }
                    var record = _records[idx];
                    // 入力レコードによって値をセット
                    //InputSystem.QueueEvent();
                    var device = InputSystem.GetDeviceById(record.deviceId) as Keyboard;
                    using (StateEvent.From(device, out var eventPtr))
                    {
                        MemoryStream ms = new MemoryStream(record.bytes);
                        ms.Position = 0;
                        BinaryFormatter bf = new BinaryFormatter();
                        object value = null;
                        try
                        {
                            if (record.type == typeof(bool))
                            {
                                value = (bool)bf.Deserialize(ms);
                            }
                            else if (record.type == typeof(float))
                            {
                                //value = (float)bf.Deserialize(ms);
                                value = 1.0f;
                            }
                            if(value == null)
                            {
                                throw new Exception("不正な型です");
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.Log(record.type);
                            ++idx;
                            break;
                        }
                        device.allControls[record.index].WriteValueFromObjectIntoEvent(eventPtr, value);
                        InputSystem.QueueEvent(eventPtr);
                    }
                    ++idx;
                }
                InputSystem.Update();
                
                if (idx >= _records.Count())
                {
                    _isRecord = false;
                    Debug.Log("End of Emulate");
                    StopCoroutine(EmurateInput());
                    break;
                }
                else
                {
                    yield return null;
                }
            }
        }

        public void PlayRecord()
        {
            if (_isRecord) return;
            _time = 0;
            _isRecord = true;
            StartCoroutine(EmurateInput());
        }


        public void OnTest1(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Disabled:
                    {

                    }
                    break;
                case InputActionPhase.Waiting:
                    {

                    }
                    break;
                case InputActionPhase.Started:
                    {
                            PlayRecord();
                    }
                    break;
                case InputActionPhase.Performed:
                    {

                    }
                    break;
                case InputActionPhase.Canceled:
                    {

                    }
                    break;
                default:
                    break;
            }
        }

        public void OnTest2(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Disabled:
                    {

                    }
                    break;
                case InputActionPhase.Waiting:
                    {

                    }
                    break;
                case InputActionPhase.Started:
                    {

                    }
                    break;
                case InputActionPhase.Performed:
                    {

                    }
                    break;
                case InputActionPhase.Canceled:
                    {

                    }
                    break;
                default:
                    break;
            }
            Debug.Log($"{context.phase} : {context.ReadValueAsObject()}");
        }

        public void OnTest3(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Disabled:
                    {

                    }
                    break;
                case InputActionPhase.Waiting:
                    {

                    }
                    break;
                case InputActionPhase.Started:
                    {

                    }
                    break;
                case InputActionPhase.Performed:
                    {

                    }
                    break;
                case InputActionPhase.Canceled:
                    {

                    }
                    break;
                default:
                    break;
            }
            Debug.Log($"{context.phase} : {context.ReadValueAsObject()}");
        }
        public void OnSaveInput(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    {
                        InputRecorder.Instance.GenerateInputRecords();
                    }
                    break;
            }
        }

        [SerializeField]
        private int _currentInputPriority;
        private List<InputProxy> _inputProxies = new List<InputProxy>();
        private bool _isRecord = false;
        private double _time;
        private List<Record> _records;
    }
}

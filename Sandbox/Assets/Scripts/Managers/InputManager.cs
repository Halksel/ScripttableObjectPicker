using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sandbox
{
    using Record = InputRecorder.ContextRecord;
    public class InputManager : SingletonMonoBehaviour<InputManager>, MyInput.IDebugActions
    {
        public enum InputMap
        {
            Debug,
            Basis,
            UI,
        }

        struct InputProxy
        {
            public InputProxy(MyInput input, InputMap inputMap, int priority)
            {
                this.input = input;
                this.inputMap = inputMap;
                this.priority = priority;
                Enable();
            }
            public void Enable()
            {
                switch (inputMap) {
                    case InputMap.Debug:
                        {
                            input.Debug.Enable();
                        }
                        break;
                    case InputMap.Basis:
                        {
                            input.Basis.Enable();
                        }
                        break;
                    case InputMap.UI:
                        {
                            input.UI.Enable();
                        }
                        break;
                }
            }
            public void Disable()
            {
                input.Disable();
            }
            public MyInput input;
            public InputMap inputMap;
            public int priority;
        }


        public override bool Setup()
        {
            var input = new MyInput();
            input.Debug.Enable();
            input.Debug.SetCallbacks(this);
            _inputProxies.Add(new InputProxy(input, InputMap.Debug, -1));
            return true;
        }

        public MyInput CreateCurrentPriorityProxy(InputMap inputMap)
        {
            var input = new MyInput();
            _inputProxies.Add(new InputProxy(input, inputMap, _currentInputPriority));
            switchInputPriority();
            return input;

        }

        public MyInput CreateTopPriorityProxy(InputMap inputMap)
        {
            ++_currentInputPriority;
            return CreateCurrentPriorityProxy(inputMap);
        }

        public void DeleteInputProxy(MyInput input)
        {
            var proxy = _inputProxies.Where(p => p.input == input).Single();
            proxy.Disable();
            _inputProxies.Remove(proxy);
            _currentInputPriority = _inputProxies.OrderBy(p => p.priority).Last().priority;
            switchInputPriority();
        }

        private void switchInputPriority()
        {
            foreach(var proxy in _inputProxies ){
                if(proxy.inputMap == InputMap.Debug)
                {
                    proxy.Enable();
                }
                else if(proxy.priority == _currentInputPriority)
                {
                    proxy.Enable();
                }
                else
                {
                    proxy.Disable();
                }
            }
        }

        IEnumerator EmurateInput()
        {
            while (true)
            {
                if (!_isRecord) yield return 0;
                _time += Time.deltaTime;
                while (_time > _records.Current.startTime)
                {
                    var record = _records.Current;
                    // 入力レコードによって値をセット

                    var next = _records.MoveNext();
                    if (!next)
                    {
                        _isRecord = false;
                        break;
                    }
                }
            }
        }

        public void PlayRecord()
        {
            _isRecord = true;
            _time = 0;
            _records = InputRecorder.Instance.GetRecords();
            StartCoroutine(EmurateInput());
        }


        // for UI 
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
        private IEnumerator<Record> _records;
    }
}

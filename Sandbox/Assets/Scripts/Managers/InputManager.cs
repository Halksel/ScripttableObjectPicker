using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sandbox
{
    using Record = InputRecorder.ContextRecord;
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
            _inputProxies.Add(new InputProxy(input, _currentInputPriority));
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

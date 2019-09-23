using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sandbox
{
    using Record = InputRecorder.ContextRecord;
    public class InputManager : SingletonMonoBehaviour<InputManager>, MyInput.ITestActions
    {
        public enum InputMap
        {
            Basis,
            UI,
        }


        public override bool Setup()
        {
            _input = new MyInput();
            _input.Test.SetCallbacks(this);
            SetCurrentState(_currentState);
            return true;
        }

        public InputMap GetCurrentState()
        {
            return _currentState;
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


        public void SetCurrentState(InputMap inputType)
        {
            _input.Disable();
            _input.Always.Enable();
            _input.Test.Enable();
            switch (inputType)
            {
                case InputMap.Basis:
                    {
                        _input.Basis.Enable();
                    }
                    break;

                case InputMap.UI:
                    {
                        _input.UI.Enable();
                    }
                    break;
            }
            _currentState = inputType;
        }


        // for UI 
        public void OnCancel(InputAction.CallbackContext context)
        {
            var record = InputRecorder.Instance.RegisterContext(InputRecorder.InputActions.Cancel, context);
            switch (record.phase)
            {
                case InputActionPhase.Started:
                    {
                        Cancel = true;
                    }
                    break;
                case InputActionPhase.Canceled:
                    {
                        Cancel = false;
                    }
                    break;
            }
        }

        public void OnEnter(InputAction.CallbackContext context)
        {
            var record = InputRecorder.Instance.RegisterContext(InputRecorder.InputActions.Enter, context);
            switch (record.phase)
            {
                case InputActionPhase.Started:
                    {
                        Enter = true;
                    }
                    break;
                case InputActionPhase.Canceled:
                    {
                        Enter = false;
                    }
                    break;
            }
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


        public bool Enter
        {
            get; private set;
        }
        public bool Cancel
        {
            get; private set;
        }

        public static MyInput Input
        {
            get { return _input; }
            private set { _input = value; }
        }

        [SerializeField]
        private InputMap _currentState = InputMap.Basis;
        private static MyInput _input;
        private bool _isRecord = false;
        private double _time;
        private IEnumerator<Record> _records;
    }
}

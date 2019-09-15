using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sandbox
{
    using Record = InputRecorder.ContextRecord;
    public class InputManager : SingletonMonoBehaviour<InputManager>, MyInput.IAlwaysActions, MyInput.IBasisActions, MyInput.IUIActions
    {
        public enum InputMap
        {
            Basis,
            UI,
        }


        public override bool Setup()
        {
            _input = new MyInput();
            _input.Always.SetCallbacks(this);
            _input.Basis.SetCallbacks(this);
            _input.UI.SetCallbacks(this);
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

        public void OnMenu(InputAction.CallbackContext context)
        {
            var record = InputRecorder.Instance.RegisterContext(InputRecorder.InputActions.Menu, context);
            menuFunc(record);
        }

        private void menuFunc(Record record)
        {
            switch (record.phase)
            {
                case InputActionPhase.Started:
                    {
                        Menu = true;
                    }
                    break;
                case InputActionPhase.Canceled:
                    {
                        Menu = false;
                    }
                    break;
            }
        }

        public void OnSaveInput(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    {
                        SaveInput = true;
                    }
                    break;
                case InputActionPhase.Canceled:
                    {
                        SaveInput = false;
                    }
                    break;
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            var record = InputRecorder.Instance.RegisterContext(InputRecorder.InputActions.Move, context);
            moveFunc(record);
        }

        private void moveFunc(Record record)
        {
            Move = (Vector2)record.value;
        }

        public void OnCursor(InputAction.CallbackContext context)
        {
            var record = InputRecorder.Instance.RegisterContext(InputRecorder.InputActions.Cursor, context);
            cursorFunc(record);
        }
        private void cursorFunc(Record record)
        {
            Cursor = (Vector2)record.value;
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            var record = InputRecorder.Instance.RegisterContext(InputRecorder.InputActions.Cancel, context);
            cancelFunc(record);
        }

        private void cancelFunc(Record record)
        {
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
            enterFunc(record);
        }
        
        private void enterFunc(Record record)
        {
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

        public bool Menu
        {
            get; private set;
        }
        public bool SaveInput
        {
            get; private set;
        }

        public Vector2 Move
        {
            get; private set;
        }

        public Vector2 Cursor
        {
            get; private set;
        }

        public bool Enter
        {
            get; private set;
        }
        public bool Cancel
        {
            get; private set;
        }

        [SerializeField]
        private InputMap _currentState = InputMap.Basis;
        private MyInput _input;
        private bool _isRecord = false;
        private double _time;
        private IEnumerator<Record> _records;
    }
}

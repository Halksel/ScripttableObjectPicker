using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sandbox
{
    public class InputManager : SingletonMonoBehaviour<InputManager>, MyInput.IAlwaysActions, MyInput.IBasisActions, MyInput.IUIActions
    {
        public enum InputType
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

        public InputType GetCurrentState()
        {
            return _currentState;
        }

        public void SetCurrentState(InputType inputType)
        {
            _input.Disable();
            _input.Always.Enable();
            switch (inputType)
            {
                case InputType.Basis:
                    {
                        _input.Basis.Enable();
                    }
                    break;

                case InputType.UI:
                    {
                        _input.UI.Enable();
                    }
                    break;
            }
            _currentState = inputType;
        }

        public void OnMenu(InputAction.CallbackContext context)
        {
            switch (context.phase)
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

        public void OnMove(InputAction.CallbackContext context)
        {
            Move = context.ReadValue<Vector2>();
        }

        public void OnCursor(InputAction.CallbackContext context)
        {
            Cursor = context.ReadValue<Vector2>();
        }

        public void OnCancel(InputAction.CallbackContext context)
        {
            switch (context.phase)
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
            switch (context.phase)
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
        private InputType _currentState = InputType.Basis;
        private MyInput _input;
    }
}

using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Sandbox
{
    public class InputManager : SingletonMonoBehaviour<InputManager>
    {
        public enum InputType
        {
            Basis,
            UI,
        }

        public override bool Setup()
        {
            _input = new MyInput();
            return true;
        }

        public InputType GetCurrentState()
        {
            return _currentState;
        }

        public void SetCurrentState(InputType inputType)
        {
            _currentState = inputType;
        }

        public Vector2 Move
        {
            get
            {
                Vector2 move = Vector2.zero;
                switch (_currentState)
                {
                    case InputType.Basis:
                        {
                            move = _input.Basis.Move.ReadValue<Vector2>();
                        }
                        break;

                    case InputType.UI:
                        {
                            Debug.Log("No Implematation!");
                        }
                        break;
                }
                return move;
            }
        }

        public Vector2 Cursor
        {
            get
            {
                Vector2 value = default(Vector2);
                switch (_currentState)
                {
                    case InputType.Basis:
                        {
                            value = _input.Basis.Cursor.ReadValue<Vector2>();
                        }
                        break;

                    case InputType.UI:
                        {
                            Debug.Log("No Implematation!");
                        }
                        break;
                }
                return value;
            }
        }

        public bool Enter
        {
            get
            {
                bool value = default(bool);
                switch (_currentState)
                {
                    case InputType.Basis:
                        {
                            value = _input.Basis.Enter.ReadValue<bool>();
                        }
                        break;

                    case InputType.UI:
                        {
                            Debug.Log("No Implematation!");
                        }
                        break;
                }
                return value;
            }
        }

        private InputType _currentState = InputType.Basis;
        private MyInput _input;
    }
}

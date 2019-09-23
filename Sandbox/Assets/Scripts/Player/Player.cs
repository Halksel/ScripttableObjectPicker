using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sandbox {
    using Record = InputRecorder.ContextRecord;
    public class Player : MonoBehaviour, BasisInput.IBasisActions, UIInput.IUIActions
    {
        private void Awake()
        {
            _basisInput = InputManager.Instance.CreateCurrentPriorityProxy(InputManager.InputType.Basis) as BasisInput;
            _basisInput.Basis.SetCallbacks(this);
        }
        private void Start () 
		{

		}
		
		private void Update () 
		{
            var delta = _move;
            transform.position += new Vector3(delta.x, delta.y);
		}

        private bool _isUI;
        private BasisInput _basisInput;
        private UIInput _uiInput;
        public Vector2 _move;
        public Vector2 _cursor;


        // basis interface
        public void OnMove(InputAction.CallbackContext context)
        {
            var record = InputRecorder.Instance.RegisterContext(InputRecorder.InputActions.Move, context);
            _move = (Vector2)record.value;
        }

        public void OnCursor(InputAction.CallbackContext context)
        {
            var record = InputRecorder.Instance.RegisterContext(InputRecorder.InputActions.Cursor, context);
            _cursor = (Vector2)record.value;
        }
        public void OnMenu(InputAction.CallbackContext context)
        {
            var record = InputRecorder.Instance.RegisterContext(InputRecorder.InputActions.Menu, context);
            switch (record.phase)
            {
                case InputActionPhase.Started:
                    {
                        if (_uiInput == null)
                        {
                            _uiInput = InputManager.Instance.CreateTopPriorityProxy(InputManager.InputType.UI) as UIInput;
                            _uiInput.UI.SetCallbacks(this);
                            _isUI = true;
                        }
                    }
                    break;
            }
        }
        // ui interface
        public void OnCancel(InputAction.CallbackContext context)
        {
            var record = InputRecorder.Instance.RegisterContext(InputRecorder.InputActions.Cancel, context);
            switch (record.phase)
            {
                case InputActionPhase.Started:
                    {
                        InputManager.Instance.DeleteInputProxy(_uiInput);
                        _uiInput = null;
                        _isUI = false;
                    }
                    break;
                case InputActionPhase.Canceled:
                    {
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
                    }
                    break;
                case InputActionPhase.Canceled:
                    {
                    }
                    break;
            }
        }
    }
}

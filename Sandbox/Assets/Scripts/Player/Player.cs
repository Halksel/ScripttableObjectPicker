using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sandbox {
    using Record = InputRecorder.ContextRecord;
    public class Player : MonoBehaviour, MyInput.IBasisActions, MyInput.IAlwaysActions
    {
        private void Awake()
        {
            InputManager.Input.Basis.SetCallbacks(this);
            InputManager.Input.Always.SetCallbacks(this);
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
        public Vector2 _move;
        public Vector2 _cursor;


        // interface
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
                        _isUI = !_isUI;
                        if (_isUI)
                        {
                            InputManager.Instance.SetCurrentState(InputManager.InputMap.UI);
                        }
                        else
                        {
                            InputManager.Instance.SetCurrentState(InputManager.InputMap.Basis);
                        }
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
                        InputRecorder.Instance.GenerateInputRecords();
                    }
                    break;
            }
        }
    }
}

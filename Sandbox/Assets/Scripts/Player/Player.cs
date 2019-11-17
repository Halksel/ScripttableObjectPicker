using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using static Sandbox.InputRecorder;

namespace Sandbox
{
    public class Player : MonoBehaviour, BasisInput.IBasisActions, UIInput.IUIActions
    {
        [InputRecorderObserved("PlayerPosition")]
        public Vector3 _pos;
        void Start()
        {
            _basisInput = _inputManager.CreateCurrentPriorityProxy(InputManager.InputType.Basis) as BasisInput;
            _basisInput.Basis.SetCallbacks(this);
            InputRecorderObservedAttribute.Regist(this.GetType(), this);
        }

        private void Update()
        {
            _move =_basisInput.Basis.Move.ReadValue<Vector2>();
            transform.position += new Vector3(_move.x, _move.y);
            _pos = transform.position;
        }

        private void OnApplicationQuit()
        {
            Debug.Log(transform.position);
        }

        // basis interface
        public void OnMove(InputAction.CallbackContext context)
        {
        }

        public void OnCursor(InputAction.CallbackContext context)
        {
            _cursor = context.ReadValue<Vector2>();
        }
        public void OnMenu(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    {
                        if (_uiInput == null)
                        {
                            _uiInput = _inputManager.CreateTopPriorityProxy(InputManager.InputType.UI) as UIInput;
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
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    {
                        _inputManager.DeleteInputProxy(_uiInput);
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
            try
            {
                switch (context.phase)
                {
                    case InputActionPhase.Started:
                        {
                            _effect = _highlightFactory.Create();
                            _effect.Setup();
                        }
                        break;
                    case InputActionPhase.Canceled:
                        {
                        }
                        break;
                }
            }
            catch(Exception e)
            {
                Debug.Log(e);
            }
        }

        [Inject]
        private InputManager _inputManager;
        [Inject]
        private InputRecorder input;

        [Inject]
        private HighlightEffect.Factory _highlightFactory;
        private HighlightEffect _effect;

        [SerializeField]
        private Texture _texture;

        private bool _isUI;
        private BasisInput _basisInput;
        private UIInput _uiInput;
        public Vector2 _move;
        public Vector2 _cursor;
    }
}

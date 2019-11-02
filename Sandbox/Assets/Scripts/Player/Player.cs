using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Sandbox
{
    public class Player : MonoBehaviour, BasisInput.IBasisActions, UIInput.IUIActions
    {
        void Start()
        {
            _basisInput = _inputManager.CreateCurrentPriorityProxy(InputManager.InputType.Basis) as BasisInput;
            _basisInput.Basis.SetCallbacks(this);
        }

        private void Update()
        {
            var delta = _move * Time.deltaTime * 2.0f;
            transform.position += new Vector3(delta.x, delta.y);
        }

        private void OnApplicationQuit()
        {
            Debug.Log(transform.position);
        }

        // basis interface
        public void OnMove(InputAction.CallbackContext context)
        {
            _move = context.ReadValue<Vector2>();
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

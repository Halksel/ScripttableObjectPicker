using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Sandbox
{
    public class Player : MonoBehaviour, BasisInput.IBasisActions, UIInput.IUIActions
    {
        [Inject]
        private InputManager inputManager;

        [Inject]
        private HighlightEffect.Factory _highlightFactory;
        private HighlightEffect _effect;

        [SerializeField]
        private Texture _texture;

        private void Awake()
        {
            _basisInput = inputManager.CreateCurrentPriorityProxy(InputManager.InputType.Basis) as BasisInput;
            _basisInput.Basis.SetCallbacks(this);
        }
        private void Start()
        {
        }

        private void Update()
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
                            _uiInput = inputManager.CreateTopPriorityProxy(InputManager.InputType.UI) as UIInput;
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
                        inputManager.DeleteInputProxy(_uiInput);
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
    }
}

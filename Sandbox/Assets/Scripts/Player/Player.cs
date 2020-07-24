using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Sandbox
{
    public class Player : MonoBehaviour, BasisInput.IBasisActions
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
            _move = _basisInput.Basis.Move.ReadValue<Vector2>();
            _pos += new Vector3(_move.x, _move.y);
            transform.position = _pos;
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
            if(context.started)
                _uiManager.PushUIPage(UIType.TopPage,"TopPage");
        }
        public void OnCancel(InputAction.CallbackContext context)
        {
            switch (context.phase)
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
        private UIManager _uiManager;
        [Inject]
        private InputRecorder input;

        [Inject]
        private HighlightEffect.Factory _highlightFactory;
        private HighlightEffect _effect;

        [SerializeField]
        private Texture _texture;

        private BasisInput _basisInput;
        public Vector2 _move;
        public Vector2 _cursor;
    }
}

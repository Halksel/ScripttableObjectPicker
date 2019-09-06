using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Sandbox
{
    public class InputProxy : MonoBehaviour, MyInput.IBasisActions
    {
        private void Awake()
        {
            _input = new MyInput();
            _input.Basis.SetCallbacks(this);
        }
        private void OnEnable()
        {
            _input.Enable(); 
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        public void Update()
        {
        }

        public void OnArrows(InputAction.CallbackContext context)
        {
            Debug.Log(context.ReadValue<Vector2>());
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Debug.Log(context.ReadValue<Vector2>());
        }

        public void OnEnter(InputAction.CallbackContext context)
        {
            Debug.Log(context.ToString());
        }

        public void OnCursor(InputAction.CallbackContext context)
        {
            Debug.Log(context.ReadValue<Vector2>());
        }

        [SerializeField]
        private MyInput _input;
    }
}

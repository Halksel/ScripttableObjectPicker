using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UnityEngine.InputSystem;

namespace Sandbox {
    abstract public class UIBase : MonoBehaviour, UIInput.IUIActions
    {
        private InputManager _inputManager;
        private InputManager.InputType _inputType = InputManager.InputType.UI;
        private UIInput _input;
        protected RectTransform _rectTransform;


        virtual public void Setup(InputManager inputManager)
        {
            _inputManager = inputManager;
            
            _input = _inputManager.CreateTopPriorityProxy(_inputType) as UIInput;
            _input.UI.SetCallbacks(this);
            gameObject.SetActive(true);
            _rectTransform = GetComponent<RectTransform>();
        }
        virtual public void TearDown()
        {
            _inputManager.DeleteInputProxy(_input);
            gameObject.SetActive(false);
            Destroy(this);
        }

        abstract public void OnCancel(InputAction.CallbackContext context);

        abstract public void OnEnter(InputAction.CallbackContext context);
    }
}

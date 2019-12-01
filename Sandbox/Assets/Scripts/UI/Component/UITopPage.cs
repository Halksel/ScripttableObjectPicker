using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Sandbox {
    public class UITopPage : UIBase , UIInput.IUIActions
    {
        public class UITopPageFactory : PlaceholderFactory<UITopPage> { }
        protected UIManager _uiManager;
        public override void Setup(InputManager inputManager)
        {
            base.Setup(inputManager);
            _rectTransform.anchoredPosition = Vector3.zero;
            _rectTransform.sizeDelta = Vector2.zero;
        }

        public override void TearDown()
        {
            base.TearDown(); 
        }

        override public void OnCancel(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _uiManager.PopUIPage();
            }
        }

        override public void OnEnter(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Debug.Log("enter");
            }
        }
    }
}

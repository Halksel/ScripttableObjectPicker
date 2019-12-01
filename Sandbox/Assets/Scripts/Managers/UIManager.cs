using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Sandbox {
    public class UIManager : MonoBehaviour
    {
        [Inject]
        UIBaseFactory _factory;
        public void PushUIPage(UIType type, string name = "")
        {
            if(_lastPageTransform == null)
            {
                _lastPageTransform = transform;
            }
            if (string.IsNullOrEmpty(name))
            {
                name = type.ToString();
            }
            var obj = _factory.Create(type);
            var page = obj.GetComponent<UIBase>();
            page.transform.SetParent(_lastPageTransform);
            page.Setup(_inputManager);
            _uiPages.Push(page);
        }

        public bool PopUIPage()
        {
            if (_uiPages.Count() <= 0) return false;
            var page = _uiPages.Pop();
            page.TearDown();
            _lastPageTransform = _uiPages.Peek().transform;
            return true;
        }
        
        [Inject]
        private InputManager _inputManager;
        Stack<UIBase> _uiPages = new Stack<UIBase>();
        Transform _lastPageTransform;
    }
}

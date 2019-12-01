using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sandbox
{
    /// <summary>
    /// 入力管理
    /// レコード読み込みで入力再現も可能
    /// </summary>
    public class InputManager : MonoBehaviour, DebugInput.IDebugActions
    {
        public enum InputType
        {
            Debug,
            Basis,
            UI,
        }

        struct InputProxy
        {
            public InputProxy(IInputActionCollection input, int priority)
            {
                this.input = input;
                this.priority = priority;
                this.input.Enable();
            }
            public IInputActionCollection input;
            public int priority;
        }

        private IInputActionCollection constructInput(InputType inputType)
        {
            switch (inputType)
            {
                case InputType.Debug:
                    return new DebugInput();
                case InputType.Basis:
                    return new BasisInput();
                case InputType.UI:
                    return new UIInput();
                default:
                    return null;
            }
        }

        public bool Setup()
        {
            var input = new DebugInput();
            input.Enable();
            input.Debug.SetCallbacks(this);
            _inputProxies.Add(new InputProxy(input, -1));
            return true;
        }

        public IInputActionCollection CreateCurrentPriorityProxy(InputType inputType)
        {
            var input = constructInput(inputType);
            if (inputType == InputType.Debug)
            {
                _inputProxies.Add(new InputProxy(input, -1));
            }
            else
            {
                _inputProxies.Add(new InputProxy(input, _currentInputPriority));
            }
            switchInputPriority();
            return input;

        }

        public IInputActionCollection CreateTopPriorityProxy(InputType inputType)
        {
            ++_currentInputPriority;
            return CreateCurrentPriorityProxy(inputType);
        }

        public void DeleteInputProxy(IInputActionCollection input)
        {
            var proxy = _inputProxies.Where(p => p.input == input).Single();
            proxy.input.Disable();
            _inputProxies.Remove(proxy);
            _currentInputPriority = _inputProxies.OrderBy(p => p.priority).Last().priority;
            switchInputPriority();
        }

        private void switchInputPriority()
        {
            foreach (var proxy in _inputProxies)
            {
                if (proxy.priority == -1 || proxy.priority == _currentInputPriority)
                {
                    proxy.input.Enable();
                }
                else
                {
                    proxy.input.Disable();
                }
            }
        }

        public void OnTest1(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Disabled:
                    {

                    }
                    break;
                case InputActionPhase.Waiting:
                    {

                    }
                    break;
                case InputActionPhase.Started:
                    {
                    }
                    break;
                case InputActionPhase.Performed:
                    {

                    }
                    break;
                case InputActionPhase.Canceled:
                    {

                    }
                    break;
                default:
                    break;
            }
        }

        public void OnTest2(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Disabled:
                    {

                    }
                    break;
                case InputActionPhase.Waiting:
                    {

                    }
                    break;
                case InputActionPhase.Started:
                    {

                    }
                    break;
                case InputActionPhase.Performed:
                    {

                    }
                    break;
                case InputActionPhase.Canceled:
                    {

                    }
                    break;
                default:
                    break;
            }
            Debug.Log($"{context.phase} : {context.ReadValueAsObject()}");
        }

        public void OnTest3(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Disabled:
                    {

                    }
                    break;
                case InputActionPhase.Waiting:
                    {

                    }
                    break;
                case InputActionPhase.Started:
                    {

                    }
                    break;
                case InputActionPhase.Performed:
                    {

                    }
                    break;
                case InputActionPhase.Canceled:
                    {

                    }
                    break;
                default:
                    break;
            }
            Debug.Log($"{context.phase} : {context.ReadValueAsObject()}");
        }
        public void OnSaveInput(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    {
                        //InputRecorder.Instance.SaveInputRecord();
                    }
                    break;
            }
        }

        public void OnLoadInput(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    {
                        //InputRecorder.Instance.LoadInputRecord();
                        //PlayRecord();
                    }
                    break;
            }
        }

        [SerializeField]
        private int _currentInputPriority;

        private List<InputProxy> _inputProxies = new List<InputProxy>();
    }
}

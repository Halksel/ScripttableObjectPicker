using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
using System;
using UnityEngine.InputSystem;

namespace Sandbox {
    unsafe public class InputTest : MonoBehaviour, DebugInput.IDebugActions
    {
        public void Start()
        {
            _input = InputManager.Instance.CreateCurrentPriorityProxy(InputManager.InputType.Debug) as DebugInput;
            _input.Enable();
            _input.Debug.SetCallbacks(this);
        }

        private DebugInput _input;

        public void OnSaveInput(InputAction.CallbackContext context)
        {
        }

        public void OnTest1(InputAction.CallbackContext context)
        {
        }

        public void OnTest2(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        public void OnTest3(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }

        unsafe public void Setup () 
		{
		}
	    
        private InputStateBlock createInputState(Type type)
        {
            InputStateBlock block = new InputStateBlock();
            block.format = InputStateBlock.GetPrimitiveFormatFromType(type);
            block.sizeInBits = (uint)InputStateBlock.GetSizeOfPrimitiveFormatInBits(block.format);
            return block;
        }
    }
}

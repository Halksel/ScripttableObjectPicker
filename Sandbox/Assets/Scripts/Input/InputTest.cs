using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
using System;

namespace Sandbox {
    unsafe public class InputTest
    {
		unsafe public void Setup () 
		{
            var value = 1.0;
            var type = value.GetType();
            InputStateBlock inputBlock = createInputState(type);
            InputStateBlock outputBlock = createInputState(type);
            inputBlock.WriteDouble(&inputBlock, value);
            inputBlock.byteOffset = 0;
            inputBlock.format = InputStateBlock.GetPrimitiveFormatFromType(type);
            Debug.Log(outputBlock.ReadDouble(&inputBlock));
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

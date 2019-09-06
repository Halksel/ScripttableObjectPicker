using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Sandbox
{
    public class InputManager : SingletonMonoBehaviour<InputManager>
    {
        struct Input
        {
            public Input(int currentPriority, InputProxy inputProxy) : this()
            {
                this.currentPriority = currentPriority;
                this.inputProxy = inputProxy;
            }

            public int _priority;
            public InputProxy _input;
            private int currentPriority;
            private InputProxy inputProxy;


            public void Enable() => _input.enabled = true;
            public void Disable() => _input.enabled = false;
        }
        override public bool Setup()
        {
            _currentPriority = 0;
            CreateCurrentPriorityInput();
            return false;
        }

        // Update is called once per frame
        void Update()
        {
        }

        public InputProxy CreateCurrentPriorityInput()
        {
            Input input = new Input( _currentPriority, new InputProxy() );
            input.Enable();
            return input._input;
        }

        public InputProxy CreateTopPriorityInput()
        {
            _currentPriority++;
            Input input = new Input( _currentPriority, new InputProxy() );
            input.Enable();
            return input._input;
        }

        public void DestroyInput(InputProxy input)
        {
            _input = _input.Where(_ => input != _._input).ToList();
        }

        private List<Input> _input = new List<Input>();
        private int _currentPriority;
    }
}

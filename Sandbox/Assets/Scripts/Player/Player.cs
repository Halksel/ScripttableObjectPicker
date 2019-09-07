using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sandbox {
    public class Player : MonoBehaviour
    {
        private MyInput input;
		private void Start () 
		{

            input = new MyInput();
		}
		
		private void Update () 
		{

            var delta = InputManager.Instance.Move;
            transform.position += new Vector3(delta.x, delta.y);
            if (InputManager.Instance.Menu)
            {
                if (_isUI)
                {
                    InputManager.Instance.SetCurrentState(InputManager.InputType.UI);
                }
                else
                {
                    InputManager.Instance.SetCurrentState(InputManager.InputType.Basis);
                }
                _isUI = !_isUI;
            }
		}

        private bool _isUI;
    }
}

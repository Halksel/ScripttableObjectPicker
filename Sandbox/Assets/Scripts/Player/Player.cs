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
                    InputManager.Instance.SetCurrentState(InputManager.InputMap.UI);
                }
                else
                {
                    InputManager.Instance.SetCurrentState(InputManager.InputMap.Basis);
                }
                _isUI = !_isUI;
                Debug.Log("Menu");
                Debug.Log(Time.deltaTime);
            }
            else if (InputManager.Instance.SaveInput)
            {
                InputRecorder.Instance.GenerateInputRecords();
                Debug.Log("Save");
                Debug.Log(Time.deltaTime);
            }
		}

        private bool _isUI;
    }
}

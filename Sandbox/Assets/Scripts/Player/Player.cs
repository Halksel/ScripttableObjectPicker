using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sandbox {
    public class Player : MonoBehaviour
    {
		private void Start () 
		{
			

		}
		
		private void Update () 
		{
            var delta = InputManager.Instance.Move;
            transform.position += new Vector3(delta.x, delta.y);

		}

    }
}

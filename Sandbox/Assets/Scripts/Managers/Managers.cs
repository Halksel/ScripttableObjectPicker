using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sandbox {
    public class Managers
    {
        private Managers()
        {

        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Setup()
        {
            var input = new GameObject("InputManager");
            input.AddComponent<InputManager>().NullCast()?.Setup() ;
        }

        private Managers Instance
        {
            get
            {
                if(Instance == null)
                {
                    instance = new Managers();
                }
                return Instance;
            }
        }

        private Managers instance;
    }
}

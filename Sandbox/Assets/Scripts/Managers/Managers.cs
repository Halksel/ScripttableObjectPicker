using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sandbox {
    public class Managers
    {
        private Managers()
        {

        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Setup()
        {
           /* CompositeResolver.RegisterAndSetAsDefault(
                StandardResolverAllowPrivate.Instance,
                MessagePack.Unity.UnityResolver.Instance,
                BuiltinResolver.Instance,
                AttributeFormatterResolver.Instance,
                DynamicEnumAsStringResolver.Instance,
                DynamicGenericResolver.Instance,
                PrimitiveObjectResolver.Instance,
                StandardResolver.Instance
            );*/


            var input = new GameObject("InputManager");
            input.AddComponent<InputManager>().NullCast()?.Setup() ;
            var inputRecorder = new GameObject("InputRecorder");
            inputRecorder.AddComponent<InputRecorder>().NullCast()?.Setup() ;
            SceneManager.LoadScene("_scn_debug");
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

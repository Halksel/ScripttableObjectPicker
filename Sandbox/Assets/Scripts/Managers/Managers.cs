using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sandbox
{
    public class Managers
    {
        private Managers()
        {

        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Setup()
        {
            //SceneManager.LoadScene("_scn_main");
            //SceneManager.LoadScene("_scn_debug");
        }

        private Managers Instance
        {
            get
            {
                if (Instance == null)
                {
                    instance = new Managers();
                }
                return Instance;
            }
        }

        private Managers instance;
    }
}

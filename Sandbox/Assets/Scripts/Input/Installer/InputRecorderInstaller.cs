using UnityEngine;
using Zenject;
using UnityEngine.InputSystem;

namespace Sandbox
{
    public class InputRecorderInstaller : MonoInstaller
    {
        [SerializeField]
        GameObject _recoder;
        public override void InstallBindings()
        {
            Container.Bind<InputRecorder>().FromComponentsInNewPrefab(_recoder).AsSingle();
        }
    }
}
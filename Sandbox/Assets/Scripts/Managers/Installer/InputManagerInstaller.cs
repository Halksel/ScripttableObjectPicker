using UnityEngine;
using Zenject;

namespace Sandbox
{
    public class InputManagerInstaller : MonoInstaller
    {
        [SerializeField]
        private InputManager _inputManagerPrefab;
        public override void InstallBindings()
        {
            Container.Bind<InputManager>().FromComponentInNewPrefab(_inputManagerPrefab).AsSingle();
        }
    }
}
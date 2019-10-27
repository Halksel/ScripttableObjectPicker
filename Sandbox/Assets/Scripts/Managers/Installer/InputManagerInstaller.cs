using UnityEngine;
using Zenject;

namespace Sandbox
{
    public class InputManagerInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _inputManagerPrefab;
        public override void InstallBindings()
        {
            Container.Bind<InputManager>().FromNewComponentOnNewPrefab(_inputManagerPrefab).AsSingle();
        }
    }
}
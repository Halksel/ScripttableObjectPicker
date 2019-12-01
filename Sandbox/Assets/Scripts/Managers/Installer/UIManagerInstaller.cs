using UnityEngine;
using Zenject;

namespace Sandbox
{
    public class UIManagerInstaller : MonoInstaller<UIManagerInstaller>
    {
        [SerializeField]
        private GameObject _uiManagerPrefab;
        public override void InstallBindings()
        {
            Container.Bind<UIBaseFactory>();
            Container.Bind<UIManager>().FromComponentInNewPrefab(_uiManagerPrefab).AsSingle();
        }
    }
}


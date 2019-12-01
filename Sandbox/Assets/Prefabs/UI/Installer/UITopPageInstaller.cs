using UnityEngine;
using Zenject;


namespace Sandbox {
    public class UITopPageInstaller : MonoInstaller
    {
        [SerializeField]
        GameObject _topPagePrefab;
        public override void InstallBindings()
        {
            Container.Bind<UITopPage>().FromComponentInNewPrefab(_topPagePrefab);
        }
    }
}
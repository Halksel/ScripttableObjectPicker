using UnityEngine;
using Zenject;

namespace Sandbox
{
    public class UIManagerInstaller : MonoInstaller<UIManagerInstaller>
    {
        public override void InstallBindings()
        {
            var obj = new GameObject("UIManager");
            obj.transform.SetParent(transform);
            Container.Bind<UIManager>().FromNewComponentOn(obj).AsSingle();
            Container.BindFactory<UIType, GameObject, UIBaseFactory>().FromFactory<CustomUIBaseFactory>();
        }
    }
}


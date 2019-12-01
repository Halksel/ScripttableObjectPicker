using UnityEngine;
using Zenject;

namespace Sandbox
{
    public class InputManagerInstaller : MonoInstaller<InputManagerInstaller>
    {
        public override void InstallBindings()
        {
            var obj = new GameObject("InputManager");
            obj.transform.SetParent(transform);
            Container.Bind<InputManager>().FromNewComponentOn(obj).AsSingle();
        }
    }
}
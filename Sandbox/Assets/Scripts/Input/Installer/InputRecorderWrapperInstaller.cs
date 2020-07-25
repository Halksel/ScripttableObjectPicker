using UnityEngine;
using Zenject;

namespace Sandbox
{
    public class InputRecorderWrapperInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var obj = new GameObject("RecorderWrapper");
            obj.transform.SetParent(transform);
            Container.Bind<InputRecorderWrapper>().FromNewComponentOn(obj).AsSingle();
        }
    }
}
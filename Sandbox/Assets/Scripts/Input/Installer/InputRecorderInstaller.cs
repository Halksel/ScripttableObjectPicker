using UnityEngine;
using Zenject;

namespace Sandbox
{
    public class InputRecorderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ITickable>().To<InputRecorder>().AsSingle();
        }
    }
}
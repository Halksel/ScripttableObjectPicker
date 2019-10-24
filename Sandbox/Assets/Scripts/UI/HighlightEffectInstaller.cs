using UnityEngine;
using Zenject;

namespace Sandbox
{
    public class HighlightEffectInstaller : MonoInstaller<HighlightEffectInstaller>
    {
        [SerializeField]
        private HighlightEffect _highlightEffectPrefab;
        public override void InstallBindings()
        {
            Container.Bind<Texture>().AsCached();
            Container.BindFactory< HighlightEffect, HighlightEffect.Factory>().FromComponentInNewPrefab(_highlightEffectPrefab).AsCached(); 
        }
    }
}

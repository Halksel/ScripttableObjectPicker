using UnityEngine;
using Zenject;

namespace Sandbox
{
    public class HighlightEffect : MonoBehaviour, IScreenEffectBase
    {
        public HighlightEffect(Texture texture)
        {
            _texture = texture;
        }

        public class Factory : PlaceholderFactory<HighlightEffect>
        {
        }

        public void Setup()
        {
            _mask.SetActive(true);
            //_material.SetTexture("_MainTex", _texture);
        }

        public void Reset()
        {
            _mask.SetActive(false);
            _material.SetTexture("_MainTex", null);
        }


        private Texture _texture;
        [SerializeField]
        private Material _material;
        [SerializeField]
        private GameObject _mask;
    }
}

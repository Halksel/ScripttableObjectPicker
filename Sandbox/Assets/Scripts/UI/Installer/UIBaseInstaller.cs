using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

namespace Sandbox {
    public enum UIType
    {
        TopPage,
        MAX,
    }

    
    public class UIBaseFactory : PlaceholderFactory<UIType ,GameObject> { }
    
    public class CustomUIBaseFactory : IFactory<UIType, GameObject>
    {
        readonly DiContainer _container;
        readonly Settings _settings;
        public CustomUIBaseFactory(DiContainer container)
        {
            _container = container;
        }
        public GameObject Create(UIType type)
        {
            if (_settings.UIPrefabs.Count() <= (int)type) return null;
            return _settings.UIPrefabs[(int)type];
        }

        [Serializable]
        public class Settings
        {
            public List<GameObject> UIPrefabs;
        }
    }

    public class UIBaseInstaller : MonoInstaller
    {
        [SerializeField]
        CustomUIBaseFactory.Settings Settings;
        public override void InstallBindings()
        {
            Container.Bind<CustomUIBaseFactory.Settings>().FromInstance(Settings);
            Container.BindFactory<UITopPage, UITopPage.UITopPageFactory>();
            Container.BindFactory<UIType, GameObject, UIBaseFactory>().FromFactory<CustomUIBaseFactory>();
        }
    }
}

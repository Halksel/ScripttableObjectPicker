using System.Linq;
using UnityEngine;

namespace Sandbox {
    /// <summary>
    /// ゲームオブジェクトへの拡張
    /// </summary>
    public static class GameObjectExtentions 
    {
        public static T AddOrGetComponent<T>(this GameObject obj) where T : UnityEngine.Component
        {
            T res = obj.GetComponent<T>();
            if(res == null)
            {
                res = obj.AddComponent<T>();
            }
            return res;
        }
    }
}

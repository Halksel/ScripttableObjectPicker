using System.Collections.Generic;
using UnityEngine;

namespace Sandbox
{
    /// <summary>
    /// List 型の拡張メソッドを管理するクラス
    /// </summary>
    public static class ListExtension
    {
        /// <summary>
        /// サイズを設定します
        /// </summary>
        public static void SetSize<T>(this List<T> self, int size)
        {
            if (self.Count <= size)
            {
                for (int i = 0; i < size - self.Count; ++i)
                    self.Add(default(T));
            }
            else
            {
                self.RemoveRange(size, self.Count - size);
            }
        }
        public static T GetRandom<T>(this List<T> self) => self[Random.Range(0, self.Count)];
    }
}
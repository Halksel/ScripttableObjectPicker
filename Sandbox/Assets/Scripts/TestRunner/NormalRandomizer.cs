using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sandbox
{
    /// <summary>
    /// 通常の乱数生成器
    /// </summary>
    public class Randomizer : IRandomizer
    {
        public float value => Random.Range(0.0f, 1.0f);
    }
}

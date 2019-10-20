namespace Sandbox
{
    /// <summary>
    /// UnityObjectへの拡張
    /// </summary>
    public static class UnityObjectExtentions
    {
        public static T NullCast<T>(this T obj) where T : UnityEngine.Object
            => (obj != null) ? obj : null;
    }
}
using UnityEditor;

namespace Sandbox
{
    public static class EditorWindowExtentions
    {
        public static void FocusGameView(this EditorWindow window)
        {
            EditorWindow.GetWindow(System.Type.GetType("UnityEditor.GameView,UnityEditor"), false, null, true);
        }
    }
}

using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Sandbox {
    public static class EditorWindowExtentions
    {
        public static void FocusGameView(this EditorWindow window)
        {
            EditorWindow.GetWindow(System.Type.GetType("UnityEditor.GameView,UnityEditor"), false, null, true);
        }
    }
}

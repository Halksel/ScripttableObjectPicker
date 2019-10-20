using UnityEngine;
using UnityEditor;

namespace Sandbox
{
    public class InputRecorderEditor : EditorWindow
    {
        [MenuItem("Custom/InputRecoder")]
        static void Open()
        {
            var window = GetWindow<InputRecorderEditor>("InputRecoder");
        }

        private void OnGUI()
        {
            var e = Event.current; 
            if (EditorApplication.isPlaying)
            {
                EditorGUILayout.LabelField(InputRecorder.Instance.IsRecord.ToString());
                if (GUILayout.Button("保存"))
                {
                    SaveInputRecord();
                }
                if (GUILayout.Button("読込 & 再生"))
                {
                    LoadInputRecord();
                }
            }
            else
            {
                EditorGUILayout.LabelField("プレイモードではない");
            }
        }

        private static void SaveInputRecord()
        {
            // 推奨するディレクトリがあればpathに入れておく
            var path = EditorUtility.SaveFilePanelInProject("Save Some Asset", "Default", "json", "hello");

            if (!string.IsNullOrEmpty(path))
            {
                // 保存処理
                InputRecorder.Instance.SaveInputRecord(path); 
            }
        }

        private static void LoadInputRecord()
        {
            var t = Time.timeScale;
            var path = EditorUtility.OpenFilePanel("Load Some Asset", "Default", "json");
            if (!string.IsNullOrEmpty(path))
            {
                Time.timeScale = 0;
                InputRecorder.Instance.IsRecord = false;
                InputRecorder.Instance.LoadInputRecord(path);
                GUI.FocusWindow(GetWindow(System.Type.GetType("UnityEditor.GameView,UnityEditor")).GetInstanceID());
                InputManager.Instance.PlayRecord();
            }
            Time.timeScale = t;
        }
    }
}

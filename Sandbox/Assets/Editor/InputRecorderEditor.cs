using UnityEngine;
using UnityEditor;

namespace Sandbox
{
    public class InputRecorderEditor : EditorWindow
    {
        static InputRecorderEditor window;
        [MenuItem("Custom/InputRecoder")]
        static void Open()
        {
            window = GetWindow<InputRecorderEditor>("InputRecoder");
        }

        private void OnGUI()
        {
            var e = Event.current; 
            if (EditorApplication.isPlaying)
            {
                EditorGUILayout.LabelField(InputRecorder.Instance.IsRecord.ToString());
                if (GUILayout.Button("記録開始"))
                {
                    StartInputRecord();
                }
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
            var path = EditorUtility.SaveFilePanelInProject("Save Some Asset", "Default", "json", "hello", "Assets/InputRecords");

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
                window.FocusGameView(); 
                InputManager.Instance.PlayRecord();
            }
            Time.timeScale = t;
        }

        private static void StartInputRecord()
        {
            InputRecorder.Instance.StartInputRecord();
            window.FocusGameView(); 
        }
    }
}

using UnityEditor;
using UnityEngine;
using Zenject;

namespace Sandbox
{
    /// <summary>
    /// InputRecorderを使いやすくするための拡張
    /// </summary>
    public class InputRecorderEditor : EditorWindow
    {
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
                if (_inputRecorder == null)
                {
                    EditorGUILayout.LabelField("InputRecoder is Null");
                    _inputRecorder = new InputRecorder();
                    _inputManager = Transform.FindObjectOfType<InputManager>();
                }
                EditorGUILayout.ToggleLeft("記録中", _inputRecorder.IsRecord);
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

        private void SaveInputRecord()
        {
            // 推奨するディレクトリがあればpathに入れておく
            var path = EditorUtility.SaveFilePanelInProject("Save Some Asset", "Default", "json", "hello", "Assets/InputRecords");

            if (!string.IsNullOrEmpty(path))
            {
                // 保存処理
                _inputRecorder.SaveInputRecord(path);
            }
        }

        private void LoadInputRecord()
        {
            var t = Time.timeScale;
            var path = EditorUtility.OpenFilePanel("Load Some Asset", "Default", "json");
            if (!string.IsNullOrEmpty(path))
            {
                Time.timeScale = 0;
                _inputRecorder.IsRecord = false;
                _inputRecorder.LoadInputRecord(path);
                window.FocusGameView();
                _inputManager.PlayRecord();
            }
            Time.timeScale = t;
        }

        private void StartInputRecord()
        {
            _inputRecorder.StartRecord();
            window.FocusGameView();
        }

        [Inject]
        private InputManager _inputManager;

        [Inject]
        private InputRecorder _inputRecorder;

        static InputRecorderEditor window;

    }
}

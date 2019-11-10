using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Sandbox
{
    /// <summary>
    /// InputRecorderを使いやすくするための拡張
    /// </summary>
    public class InputRecorderEditor : ZenjectEditorWindow
    {
        public override void InstallBindings()
        {
            Container.Bind<InputRecorder>().AsSingle();
            _inputRecorder = Container.Resolve<InputRecorder>();
        }

        [MenuItem("Custom/InputRecoder")]
        static void Open()
        {
            window = GetWindow<InputRecorderEditor>("InputRecoder");
        }

        public override void OnGUI()
        {
            var e = Event.current;
            if (EditorApplication.isPlaying)
            {
                if (!_isNoPaint)
                {
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
                    if (GUILayout.Button("ランダム生成"))
                    {
                        RandomGenerateInputRecord();
                    }
                }
                if (_inputRecorder == null || _inputManager == null)
                {
                    if (_inputRecorder == null)
                        EditorGUILayout.LabelField("InputRecoder is Null");
                    if (_inputManager == null)
                        EditorGUILayout.LabelField("InputManager is Null");

                    //_inputRecorder = new InputRecorder();
                    _inputManager = Transform.FindObjectOfType<InputManager>();
                    _isNoPaint = true;
                }
                else
                {
                    _isNoPaint = false;
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
                window.FocusGameView();
                _inputManager.StartCoroutine(_inputRecorder.EmurateInput(path));
            }
            Time.timeScale = t;
        }

        private void StartInputRecord()
        {
            _inputRecorder.StartRecord();
            window.FocusGameView();
        }

        private void RandomGenerateInputRecord()
        {
            var values = new List<string> {"a", "w", "s", "d" };
            _inputRecorder.GenerateInputRecord(values, 1, 10, 120, 5);
            _inputRecorder.SaveInputRecord($"Assets/InputRecords/Random/{DateTime.Now.ToString("yy_MM_dd_HH_mm")}.json");
        }

        private InputManager _inputManager;

        [Inject]
        private InputRecorder _inputRecorder;

        static InputRecorderEditor window;

        private bool _isNoPaint;
    }
}

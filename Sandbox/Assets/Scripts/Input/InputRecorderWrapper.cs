using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Sandbox
{
    /// <summary>
    /// 入力記録
    /// 自作をあきらめてUnity製のをラッピング
    /// </summary>
    public class InputRecorderWrapper : MonoBehaviour
    {
        [Serializable]
        public class InputRecorderValue
        {
            public InputRecorderValue(string name, string value)
            {
                this.name = name;
                this.value = value;
            }

            public static bool operator ==(InputRecorderValue a, InputRecorderValue b)
            {
                return a.name == b.name && a.value == b.value;
            }
            public static bool operator !=(InputRecorderValue a, InputRecorderValue b)
            {
                return !(a == b);
            }
            public string name;
            public string value;

            public override bool Equals(object obj)
            {
                return obj is InputRecorderValue value &&
                       name == value.name &&
                       this.value == value.value;
            }

            public override int GetHashCode()
            {
                var hashCode = 1477024672;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(value);
                return hashCode;
            }
        }

        /// <summary>
        /// List<T> をJsonUtilityはシリアライズできないのでラッパークラス
        /// 端的にゴミ
        /// </summary>
        [Serializable]
        public class InputRecorderValues 
        {
            public List<InputRecorderValue> firstValues = new List<InputRecorderValue>();
            public List<InputRecorderValue> lastValues = new List<InputRecorderValue>();

            public bool CheckValues(List<InputRecorderValue> values)
            {
                bool flag = true;
                if (values.Count != lastValues.Count) return false;
                for(int i = 0; i < values.Count; ++i)
                {
                    flag &= values[i] == lastValues[i];
                    if (!flag)
                    {
                        return false;
                    }
                }
                return true;
            }
            public void SaveValues(List<InputRecorderValue> values, bool isFirst)
            {
                if (isFirst)
                {
                    firstValues.AddRange(values);
                }
                else
                {
                    lastValues.AddRange(values);
                }
            }
            public void Reset()
            {
                lastValues.Clear();
                firstValues.Clear();
            }
        }

        public void Start()
        {
            //Recorder.changeEvent.AddListener(changeEvent);
        }

        private void OnStartCapture()
        {
            _records.Reset();
            _records.SaveValues(InputRecorderObservedAttribute.GetObserevedValuesReflection(), true);
        }

        private void OnStopCapture()
        {

            var path = SaveDirectory;
            _records.SaveValues(InputRecorderObservedAttribute.GetObserevedValuesReflection(), false);
            var json = JsonUtility.ToJson(_records, true);
            var encoding = new UTF8Encoding(true, false);
            File.WriteAllText(path, json, encoding);

            AssetDatabase.ImportAsset(path);
            var asset = AssetDatabase.LoadAssetAtPath<TextAsset>(path);
            ProjectWindowUtil.ShowCreatedAsset(asset);

            AssetDatabase.Refresh();
        }

        private void OnStartReplay()
        {
            var path = SaveDirectory;
            var encoding = new UTF8Encoding(true, false);
            var json = File.ReadAllText(path, encoding);
            try
            {
                _records = JsonUtility.FromJson<InputRecorderValues>(json);
                InputRecorderObservedAttribute.SetObservedValuesReflection(_records.firstValues);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void changeEvent(InputRecorder.Change change)
        {
            switch (change)
            {
                case InputRecorder.Change.None:
                    break;
                case InputRecorder.Change.EventCaptured:
                    break;
                case InputRecorder.Change.EventPlayed:
                    break;
                case InputRecorder.Change.CaptureStarted:
                    OnStartCapture();
                    break;
                case InputRecorder.Change.CaptureStopped:
                    OnStopCapture();
                    break;
                case InputRecorder.Change.ReplayStarted:
                    OnStartReplay();
                    break;
                case InputRecorder.Change.ReplayStopped:
                    break;
            }

        }

        [Inject]
        public UnityEngine.InputSystem.InputRecorder Recorder;
        private InputRecorderValues _records = new InputRecorderValues();
        public InputRecorderValues RecorderValues
        {
            get { return _records; }
        }
        private string _saveDirectory;
        public string SaveDirectory 
        {
            get
            {
                if (_saveDirectory == null)
                {
                    _saveDirectory = Application.dataPath + $"/InputRecords/Tests/test.json";
                    return _saveDirectory;
                }
                return _saveDirectory;
            }
            set
            {
                _saveDirectory = value;
            }
        }
        
    }
}

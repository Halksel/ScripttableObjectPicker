using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using UnityEngine.SceneManagement;

namespace Sandbox
{

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class InputRecorderObservedAttribute : Attribute
    {
        static Type typeAttr = typeof(InputRecorderObservedAttribute);
        static private bool isRegistered = false;
        private string _name;
        private static List<KeyValuePair<Type, object>> types = new List<KeyValuePair<Type, object>>();
        public static void Regist(Type t, object obj)
        {
            types.Add(new KeyValuePair<Type, object>(t, obj));
            if (!isRegistered)
            {
                SceneManager.sceneLoaded += SceneManager_sceneLoaded;
                isRegistered = true;
            }
        }

        private static void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            types.Clear();
        }

        public static IReadOnlyList<KeyValuePair<Type, object>> Get()
        {
            return types; 
        }
        public InputRecorderObservedAttribute(string name) { _name = name; }
        public string Name { get { return _name; } }

        public static List<InputRecorderWrapper.InputRecorderValue> GetObserevedValuesReflection()
        {
            var result = new List<InputRecorderWrapper.InputRecorderValue>();
            for (int i = 0; i < types.Count; ++i)
            {
                var type = types[i].Key;
                var obj = types[i].Value;
                if (obj.ToString() == "null") continue;
                FieldInfo[] fields = type.GetFields();
                foreach (FieldInfo fieldInfo in fields)
                {
                    var attributes = Attribute.GetCustomAttributes(
                        fieldInfo, typeAttr) as InputRecorderObservedAttribute[];

                    if (attributes == null) continue;
                    foreach (var attribute in attributes)
                    {
                        //属性が定義されたプロパティだけを参照するため、fixedAttrがnullなら処理の対象外
                        if (attribute != null)
                        {
                            var value = new InputRecorderWrapper.InputRecorderValue(attribute.Name, fieldInfo.GetValue(obj as object).ToString());
                            result.Add(value);
                        }
                    }
                }
            }
            return result;
        }

        public static bool SetObservedValuesReflection(List<InputRecorderWrapper.InputRecorderValue> values)
        {
            if (types.Count != values.Count) return false;
            for (int i = 0; i < values.Count; ++i)
            {
                var type = types[i].Key;
                var obj = types[i].Value;
                FieldInfo[] fields = type.GetFields();
                foreach (FieldInfo fieldInfo in fields)
                {
                    var attributes = Attribute.GetCustomAttributes( fieldInfo, typeAttr)as InputRecorderObservedAttribute[];
                    if (attributes == null) continue;
                    foreach (var attribute in attributes)
                    {
                        //属性が定義されたプロパティだけを参照するため、fixedAttrがnullなら処理の対象外
                        if (attribute != null && attribute.Name == values[i].name)
                        {
                            object convertedValue;

                            ConvertStr2Type(values[i].value ,fieldInfo.FieldType, out convertedValue);
                            if (convertedValue != null)
                                fieldInfo.SetValue(obj, convertedValue);
                        }
                    }
                }
            }
            return true;
        }

        private static void ConvertStr2Type(string value, Type type, out object Result)
        {
            if (typeof(IConvertible).IsAssignableFrom(type))
            {
                Result = Convert.ChangeType(value, type);
                return;
            }
            else
            {
                if(type == typeof(Vector3))
                {
                    Result = StringToVector3(value);
                    return;
                }
            }

            Result = null;
        }

        public static Vector3 StringToVector3(string sVector)
        {
            // Remove the parentheses
            if (sVector.StartsWith("(") && sVector.EndsWith(")")) {
                sVector = sVector.Substring(1, sVector.Length - 2);
            }

            // split the items
            string[] sArray = sVector.Split(',');

            // store as a Vector3
            Vector3 result = new Vector3(
                float.Parse(sArray[0]),
                float.Parse(sArray[1]),
                float.Parse(sArray[2]));

            return result;
        }
    }
}

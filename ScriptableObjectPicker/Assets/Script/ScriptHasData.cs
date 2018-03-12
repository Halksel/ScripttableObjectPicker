using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ScriptHasData : MonoBehaviour {
	public List<DataScriptableObject> datas;
	private List<string> paths;
	private int size;
	// Use this for initialization
	void Start () {
		datas = new List<DataScriptableObject>();
		paths = new List<string>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	[CustomEditor(typeof(ScriptHasData))]
	public class ScriptHasDataEditor : Editor{
		bool isSpecialFold = true;
		string datapath = "Assets/Data/ScriptableObject";
		List<string> paths;
		string[] names;
		void Awake ()
		{
			var t = target as ScriptHasData;
		
			paths = new List<string>(Directory.GetFiles (datapath, "*.asset"));
			names = new string[paths.Count] ;
			for(int i = 0; i < paths.Count;++i){
				var n = AssetDatabase.LoadAssetAtPath<DataScriptableObject> (paths [i]) as DataScriptableObject;
				names[i] = Path.GetFileNameWithoutExtension (paths [i]);
			}
		}
		public override void OnInspectorGUI ()
		{
			serializedObject.Update();
			EditorGUI.BeginChangeCheck();
			var script = target as ScriptHasData;

			isSpecialFold = EditorGUILayout.Foldout(isSpecialFold,"datas");
			if(isSpecialFold){
				SerializedProperty sp = serializedObject.FindProperty ("datas");
				script.size = EditorGUILayout.IntField("size",script.size);
				script.datas.SetSize(script.size);
				script.paths.SetSize(script.size);
				for(int i = 0; i < script.datas.Count;++i){
					int idx = EditorGUILayout.Popup(paths.IndexOf(script.paths[i]),names);
					if(idx < 0) idx = 0;
					script.paths[i] = paths[idx];
					script.datas[i] = AssetDatabase.LoadAssetAtPath<DataScriptableObject>(paths[idx]) as DataScriptableObject;
				}
			}

			if(EditorGUI.EndChangeCheck())
				serializedObject.ApplyModifiedProperties();
		}
	}
}

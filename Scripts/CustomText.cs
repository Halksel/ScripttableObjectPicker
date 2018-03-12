using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UniRx;

public class CustomText : Text {
	[SerializeField]
	private MonoBehaviour tar;
	[SerializeField,HideInInspector]
	private string targetPropertyName;
	[SerializeField,HideInInspector]
	private string format = "***";
	[SerializeField,HideInInspector]
	private int index;
	private string preTargetPropertyName;
	private Type preType;
	private PropertyInfo numberInfo;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(targetPropertyName != preTargetPropertyName) {
			var prop2 = tar.GetType ();
			numberInfo = tar.GetType ().GetProperty (targetPropertyName);
			Type t = numberInfo.PropertyType;
			var number = Convert.ChangeType (numberInfo.GetValue (tar, null), t);
			var str = format.Replace ("***", number.ToString ());
			text = str;
			preType = t;
			preTargetPropertyName = targetPropertyName;
		}
		else{
			var number = Convert.ChangeType (numberInfo.GetValue (tar, null), preType);
			var str = format.Replace ("***", number.ToString ());
			text = str;
		}
	}
	[CustomEditor(typeof(CustomText))]
	public class CustomTextEditor : Editor{
		CustomText cText;
		MonoBehaviour component;
		string[] properties = new string[]{};
		void Awake(){
		}

		void Update(){
			
		}

		void CollectProperties(){
			cText = target as CustomText;
			component = cText.tar;
			ArrayList result = new ArrayList();

			result.Add("not selected");
			if(component == null) return;
			Debug.Log(component.name);
			string[] propertiesName = component.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
				.Select(x => x.Name)
				.ToArray();
			result.AddRange(propertiesName);
			properties = (string[])result.ToArray(typeof(string));
		}

		void OnEnable(){
			serializedObject.Update ();
			EditorGUI.BeginChangeCheck ();
			CollectProperties();
			if (EditorGUI.EndChangeCheck ())
				serializedObject.ApplyModifiedProperties ();
		}

		public override void OnInspectorGUI ()
		{
			serializedObject.Update ();
			EditorGUI.BeginChangeCheck ();
			Debug.Log(properties.Length);
			base.OnInspectorGUI ();
			if(properties.Length <= 0) return;

			var prop = properties
				.Select((Name,Index) => new {Name, Index } )
				.FirstOrDefault(x => x.Name == cText.targetPropertyName);
				//.Index;
			if (prop == null){
				Debug.Log(cText.index);
				Debug.Log("index reseted");
				cText.index = 0;
			}
			else{
				cText.index = prop.Index;
			}

			using( new EditorGUILayout.HorizontalScope()){
				EditorGUILayout.LabelField("Target Property");
				cText.targetPropertyName = properties[EditorGUILayout.Popup(cText.index,properties)];
			}
			if(cText.index == 0) return ;
			using(new EditorGUILayout.VerticalScope()){
				cText.format = EditorGUILayout.TextField("format",cText.format);
				var prop2 = cText.tar.GetType();
				var numberInfo = cText.tar.GetType().GetProperty(cText.targetPropertyName);
				Type t = numberInfo.PropertyType;
				var number = Convert.ChangeType(numberInfo.GetValue(cText.tar,null),t);
				var str = cText.format.Replace("***",number.ToString());
				cText.text = str;
				EditorGUILayout.TextArea(cText.text);
			}
			if (EditorGUI.EndChangeCheck ())
				serializedObject.ApplyModifiedProperties ();
		}
	}
}

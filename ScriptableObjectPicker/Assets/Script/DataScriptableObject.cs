using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu( menuName = "Data/Create DataScriptableObject", fileName = "ScriptableObject" ),System.Serializable]
public class DataScriptableObject : ScriptableObject{
	//any datas
	public int hoge;
}
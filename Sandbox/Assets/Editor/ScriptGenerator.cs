using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.ProjectWindowCallback;
using System.Text;

public class ScriptGenerator : EndNameEditAction
{

    public static readonly string CODE_TEMPLATE = $@"using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sandbox {{
    public class #SCRIPTNAME# : MonoBehaviour
    {{
		private void Start () 
		{{
			#NOTRIM#
		}}
		
		private void Update () 
		{{
			#NOTRIM#
		}}
    }}
}}
";

    public static readonly string EDITOR_TEMPLATE = $@"using UnityEngine;
using UnityEditor;

public class #SCRIPTNAME# : EditorWindow
{{
    static void Open(){{
        var window = GetWindow<#SCRIPTNAME#>();
        #NOTRIM#
    }}


    private void OnGUI()
    {{
        #NOTRIM#
    }}
}}
";

    [MenuItem("Assets/Create/C# Script Ext/MonoBehaviour", priority = 21)]
    private static void GenerateMonoScriptTempleate()
    {
        Debug.Log(Selection.activeObject.name);

        var csIcon = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;

        var endNameEditAction = ScriptableObject.CreateInstance<ScriptGenerator>();

        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, endNameEditAction, "NewBehaviourScript.cs", csIcon, CODE_TEMPLATE);
    }

    [MenuItem("Assets/Create/C# Script Ext/Editor", priority = 21)]
    private static void GenerateEditorScriptTempleate()
    {
        Debug.Log(Selection.activeObject.name);

        var csIcon = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;

        var endNameEditAction = ScriptableObject.CreateInstance<ScriptGenerator>();

        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, endNameEditAction, "NewEditorScript.cs", csIcon, EDITOR_TEMPLATE);
    }

    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        var text = resourceFile;
        var pathes = Application.dataPath.Split('/');

        var name = Path.GetFileNameWithoutExtension(pathName);
        var scriptName = name.Replace(" ", "");
        var projectName = "." + pathes[pathes.Length - 2];
        var directryName = Path.GetDirectoryName(pathName).Replace("Assets", "").Replace("/Scripts", "").Replace("/", ".");


        text = text.Replace("#NAME#", name);
        text = text.Replace("#SCRIPTNAME#", scriptName);
        text = text.Replace("#PROJECTNAME#", projectName);
        text = text.Replace("#DIRECTORYNAME#", directryName);
        text = text.Replace("#NOTRIM#", "\r\n");

        var encoding = new UTF8Encoding(true, false);

        File.WriteAllText(pathName, text, encoding);

        AssetDatabase.ImportAsset(pathName);
        var asset = AssetDatabase.LoadAssetAtPath<MonoScript>(pathName);
        ProjectWindowUtil.ShowCreatedAsset(asset);

        AssetDatabase.Refresh();
    }
}

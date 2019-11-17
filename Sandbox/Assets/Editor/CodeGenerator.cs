using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class MenuItems : Editor {
    [MenuItem ("MessagePack/CodeGenerate")]
    private static void Generate () {
        ExecuteMessagePackCodeGenerator ();
    }

    private static void ExecuteMessagePackCodeGenerator () {
        UnityEngine.Debug.Log ($"{nameof(ExecuteMessagePackCodeGenerator)} : start");

        var exProcess = new Process ();

        var rootPath = Application.dataPath + "/..";
        var filePath = rootPath + "/GeneratorTools/MessagePackUniversalCodeGenerator";
        var exeFileName = "";
#if UNITY_EDITOR_WIN
        exeFileName = "/win-x64/mpc.exe";
#elif UNITY_EDITOR_OSX
        exeFileName = "/osx-x64/mpc";
#elif UNITY_EDITOR_LINUX
        exeFileName = "/linux-x64/mpc";
#else
        return;
#endif

        var psi = new ProcessStartInfo () {
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            FileName = filePath + exeFileName,
            Arguments = $@"-i ""{Application.dataPath}/../Assembly-CSharp.csproj"" -o ""{Application.dataPath}/Scripts/Generated/MessagePackGenerated.cs""",
        };

        var p = Process.Start (psi);

        p.EnableRaisingEvents = true;
        p.Exited += (object sender, System.EventArgs e) => {
            var data = p.StandardOutput.ReadToEnd ();
            UnityEngine.Debug.Log ($"{data}");
            UnityEngine.Debug.Log ($"{nameof(ExecuteMessagePackCodeGenerator)} : end");
            p.Dispose ();
            p = null;
        };
    }
}

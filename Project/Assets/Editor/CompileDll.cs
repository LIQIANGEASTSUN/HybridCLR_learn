using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Player;
using System.IO;

public class CompileDll
{

    [MenuItem("Tools/CompileDll")]
    static void Compile()
    {
        BuildTarget target = BuildTarget.StandaloneWindows64;
        ScriptCompilationSettings scriptCompilationSettings = new ScriptCompilationSettings();
        scriptCompilationSettings.group = BuildPipeline.GetBuildTargetGroup(target);
        scriptCompilationSettings.target = target;

        string outDir = string.Format("{0}\\DLL", Application.dataPath);
        if (!Directory.Exists(outDir))
        {
            Directory.CreateDirectory(outDir);
        }

        ScriptCompilationResult scriptCompilationResult = PlayerBuildInterface.CompilePlayerScripts(scriptCompilationSettings, outDir);
        foreach(var ass in scriptCompilationResult.assemblies)
        {
            Debug.LogFormat("compile assemblies:{0}/{1}", outDir, ass);
        }
    }

}

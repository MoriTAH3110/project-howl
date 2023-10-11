using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public static class SceneUtilityHelper 
{
    public static string[] GetSceneNamesInBuildSettings()
    {
        return EditorBuildSettings.scenes
        .Where(scene => scene.enabled)
        .Select(scene => System.IO.Path.GetFileNameWithoutExtension(scene.path))
        .ToArray();
    }
}

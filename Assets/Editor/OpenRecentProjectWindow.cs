using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using PlistCS;
using System.Diagnostics;
using System.IO;

public class OpenRecentProjectWindow : EditorWindow {

    static OpenRecentProjectWindow window_;
    // [MenuItem("Utils/Open Recent Projects %#o")]
	public static void OpenRecentProjects () {
        window_ = (OpenRecentProjectWindow)EditorWindow.GetWindow(typeof(OpenRecentProjectWindow), true, "Open Recent Projects");
        window_.ShowPopup();
    }

	/// <summary>
	/// OnGUI is called for rendering and handling GUI events.
	/// This function can be called multiple times per frame (one call per event).
	/// </summary>
	void OnGUI()
	{
        List<string> recentFiles = GetRecentProjects();

		GUILayout.BeginVertical();
		for (int i = 0; i < recentFiles.Count; i++)
		{
            if (GUILayout.Button(recentFiles[i])) {
				UnityEngine.Debug.Log (recentFiles[i]);
                OpenProject("");
            }
        }

		GUILayout.EndVertical();
    }

	static List<string> GetRecentProjects () {
        string path = "/Users/oyyming/Library/Preferences/com.unity3d.UnityEditor5.x.plist";
        Dictionary<string, object>  temp = (Dictionary<string, object>)Plist.readPlist(path);
        List<string> recentFiles = new List<string>();
        foreach (var mem in temp)
        {
			if (mem.Key.Contains("RecentlyUsedProjectPaths"))
                recentFiles.Add((string)temp[mem.Key]);
        }

        // Sort
        recentFiles.Sort((a, b) => string.Compare(a, b, true));

        return recentFiles;
    }

	static void OpenProject (string path) {
		
    }

}

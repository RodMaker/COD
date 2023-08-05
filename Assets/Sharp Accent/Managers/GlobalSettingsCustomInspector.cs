#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SA.Settings
{
	[CustomEditor(typeof(GlobalSettingsAsset))]
	public class GlobalSettingsCustomInspector : Editor
	{
		//use this script to create a custom inspector for your global settings

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
		}


		//this is to get a menu item for quick selection
		[MenuItem("Sharp Accent/Tools/Global Settings")]
		static void SelectGlobalSettings()
		{
			string[] paths = AssetDatabase.FindAssets("GlobalSettingsObj");
			string targetPath = AssetDatabase.GUIDToAssetPath(paths[0]);
			Debug.Log(targetPath);
			GlobalSettingsAsset p = (GlobalSettingsAsset)AssetDatabase.LoadAssetAtPath(targetPath,
				typeof(GlobalSettingsAsset));
			Selection.SetActiveObjectWithContext(p, p);
		}
	}
}
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA.Settings
{
	[CreateAssetMenu(menuName ="Utilities/Global Settings")]
	public class GlobalSettingsAsset : ScriptableObject
	{
		public bool thisIsATest;


		public void Init()
		{
			//add init code in here, such as loading options etc
		}
	}
}

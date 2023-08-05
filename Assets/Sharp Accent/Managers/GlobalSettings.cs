using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA.Settings;

namespace SA
{
	public class GlobalSettings 
	{
		static GlobalSettingsAsset _settings;
		public static GlobalSettingsAsset settings {
			get {
				if (_settings == null)
				{
					_settings = Resources.Load("GlobalSettingsAsset") as GlobalSettingsAsset;
					_settings.Init();
				}
				return _settings;
			}
		}
	}
}

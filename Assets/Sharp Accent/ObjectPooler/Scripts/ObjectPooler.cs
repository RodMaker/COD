using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA.Utilities.ObjectPool;

namespace SA.Utilities
{
	public static class ObjectPooler 
	{
		static ObjectPoolAsset _poolAsset;

		public static ObjectPoolAsset objectPooler {
			get {

				if (_poolAsset == null)
				{
					_poolAsset = Resources.Load("ObjectPooler") as ObjectPoolAsset;
					_poolAsset.Init();
				}

				return _poolAsset;
			}
		}

		public static GameObject GetObject(string id)
		{
			return objectPooler.GetObject(id);
		}
	}
}

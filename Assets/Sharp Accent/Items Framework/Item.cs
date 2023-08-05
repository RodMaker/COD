using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA.Items
{
	public abstract class Item : ScriptableObject
	{
		public ItemType itemType;
		public GameObject prefab;
	}
}

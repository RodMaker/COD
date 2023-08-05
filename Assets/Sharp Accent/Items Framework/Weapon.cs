using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA.Items
{
	[CreateAssetMenu(menuName ="Items/Weapon")]
	public class Weapon : Item
	{
		public float fireRate = 0.1f;
		public int magazineBullets = 20;
		public int maxBullets = 120;
	}
}

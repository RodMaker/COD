using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA.Items
{
	public class RuntimeItem 
	{
		public string instanceId;
		public Item baseItem;

		public int currentBullets;
		public int maxBulletsCarrying;

		float lastFired;

		public bool canFire()
		{
			if (currentBullets > 0)
			{
				Weapon w = (Weapon)baseItem;
				return (Time.realtimeSinceStartup - lastFired) > w.fireRate;
			}

			return false;	
		}

		public void Shoot()
		{
			lastFired = Time.realtimeSinceStartup;
			currentBullets--;
		}

		public void Reload() 
		{ 
			Weapon w = (Weapon)baseItem;
			currentBullets = w.magazineBullets;

			/*if (maxBulletsCarrying > w.magazineBullets)
			{
				currentBullets = w.magazineBullets;
				maxBulletsCarrying -= w.magazineBullets;
			}
			else
			{
				int dif = w.magazineBullets - maxBulletsCarrying;
				currentBullets = dif;
				maxBulletsCarrying = 0;
			}*/
		}
	}
}

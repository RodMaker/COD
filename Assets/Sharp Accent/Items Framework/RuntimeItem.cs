using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA.Items
{
	public class RuntimeItem 
	{
		public string instanceId;
		public Item baseItem;
		public Weapon weapon
		{
			get
			{
				return (Weapon)baseItem;
			}
		}

		public RuntimeItem(Item baseItem)
		{
			this.baseItem = baseItem;

			if (baseItem is Weapon)
			{
				InitWeapon();
			}
		}

		public int currentBullets;
		public int maxBulletsCarrying;

		float lastFired;

		public void InitWeapon()
		{
			maxBulletsCarrying = weapon.maxBullets;
		}

		public bool canFire()
		{
			if (currentBullets > 0)
			{
				return (Time.realtimeSinceStartup - lastFired) > weapon.fireRate;
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
			if (maxBulletsCarrying > weapon.magazineBullets)
			{
				currentBullets = weapon.magazineBullets;
				maxBulletsCarrying -= weapon.magazineBullets;
			}
			else
			{
				currentBullets = maxBulletsCarrying;
				maxBulletsCarrying = 0;
			}
		}
	}
}

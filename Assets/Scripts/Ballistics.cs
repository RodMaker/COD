using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA.Utilities;
using SA;

namespace RM
{
    public static class Ballistics
    {
        public static void RaycastBullet(Vector3 origin, Vector3 direction, Controller owner)
        {
            GameObject bulletGo = ObjectPooler.GetObject("bulletLine");

            Vector3 hitPosition = origin + (direction * 100);
            RaycastHit hit;
            if (Physics.Raycast(origin, direction, out hit, 100))
            {
                hitPosition = hit.point;
            }

            BulletLine bulletLine = bulletGo.GetComponentInChildren<BulletLine>();
            bulletLine.SetPositions(origin, hitPosition);
            bulletGo.SetActive(true);
        }
    }
}

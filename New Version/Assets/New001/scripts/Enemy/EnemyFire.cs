using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Teddy
{
    ///<summary>
    ///敵人射擊
    ///</summary>
    public class EnemyFire : MonoBehaviour
    {
        [Header("槍口")]
        public Transform firePoint;
        public Transform firePoint2;
        public Transform firePoint3;
        public Transform firePoint4;
        [Header("敵人子彈")]
        public GameObject bulletPrefab;
        public bool autoShoot = false;
        [Header("子彈延遲")]
        public float shootIntervalSeconds = 0.5f;
        [Header("開始射擊延遲")]
        public float shootDelaySeconds = 0f;
        float shootTimer = 0f;
        float delayTimer = 0f;

        // Update is called once per frame
        void Update()
        {
            if(transform.position.x < 11f && !autoShoot)
            {
                autoShoot = true;
            }
            if(autoShoot)
            {
                if(delayTimer >= shootDelaySeconds)
                {
                  if(shootTimer >= shootIntervalSeconds)
                  {
                    Shoot();
                    shootTimer = 0;
                  }
                  else
                  {
                    shootTimer += Time.deltaTime;
                  }
                }
                else
                {
                    delayTimer += Time.deltaTime;
                }
            }
        }
        void Shoot()
        {
            #region 槍口控制
            if(firePoint != null)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            }
            if(firePoint2 != null)
            {
                Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
            }
            if(firePoint3 != null)
            {
                Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
            }
            if(firePoint4 != null)
            {
                Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);
            }
            #endregion 
        }
    }
}


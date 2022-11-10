using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Teddy
{
    ///<summary>
    ///BossLevel
    ///</summary>
    public class BossLevel : MonoBehaviour
    {
       public GameObject miniBoss;
       public GameObject miniBoss2;
       public GameObject Laser;
       private Animator anim;

       float nextBossLevelTimer = 15;
       int currentBossLevel = 1;

      private void Start() 
      {
        anim = GetComponent<Animator>();
      }
       
       private void Update() 
       {
        if(nextBossLevelTimer <= 0 && currentBossLevel == 1)
        {
            currentBossLevel++;
            nextBossLevelTimer = 10;
            BossLevel2();
        }
        else if(nextBossLevelTimer <= 0 && currentBossLevel == 2)
        {
            currentBossLevel++;
            nextBossLevelTimer = 15;
            BossLevel3();
        }
        else if(nextBossLevelTimer <= 0 && currentBossLevel == 3)
        {
            BossEnd();
        }
        else
        {
            nextBossLevelTimer -= Time.deltaTime;
        }
       }

      
       void BossLevel2()
       {
        anim.SetBool("colorchange", true);
        Invoke("MiniBossAppear", 2.5f);
       }
       void BossLevel3()
       {
        Invoke("ShootChange", 9f);
        Invoke("MiniBossDisappear", 9f);
        Invoke("LaserAppear", 10f);
        Invoke("Kamehameha", 7f);
       }
       void BossEnd()
       {
        gameObject.GetComponent<Teddy.Destructable>().enabled = true;
       }



       void MiniBossAppear()
       {
        miniBoss.SetActive(true);
        miniBoss2.SetActive(true);
       }
       void MiniBossDisappear()
       {
        miniBoss.SetActive(false);
        miniBoss2.SetActive(false);
       }
       void ShootChange()
       {
        GetComponent<Teddy.BossFire>().autoShoot = false;
       }
       void LaserAppear()
       {
        Laser.SetActive(true);
       }
       void Kamehameha()
       {
        GetComponent<AudioSource>().Play();
       }
    }
}

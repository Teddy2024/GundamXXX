using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Teddy
{
  public class Fire : MonoBehaviour
  {
    [Header("Level0")]
    public Transform firePoint;
    public Transform firePoint2;
    public GameObject bulletPrefab;
    [Header("Level1")]
    public Transform firePoint3;
    public GameObject bulletPrefab2; 
    [Header("Level2")]
    public Transform firePoint4;
    public Transform firePoint5;
    public Transform firePoint6;
    public Transform firePoint7;
    
    private float time = 0;
    public float BulletInterval = 0.2f;
    [Header("槍枝等級")]
    public int GunLevel = 0;
    [Header("電力值")]
    public Energybar energyBar;
    public float EnergyInterval = 3f;  
    public int maxEnergy = 100;
    public int currentEnergy;
    
      
    void Start()
    {
      currentEnergy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
      time += Time.deltaTime;
      if(Input.GetKey(KeyCode.J) && time>BulletInterval)
      {
        Shoot();
        time = 0;
      }
    }


    private void FixedUpdate() 
    {
      if(!Input.GetKey(KeyCode.J) && time >= EnergyInterval)
      {
        RecoverEnergy(1);
      }
    }
      
    void Shoot()
    {
      if(currentEnergy >= 2)
      {
        CostEnergy(2);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        if(GunLevel >= 1)
        {
          Instantiate(bulletPrefab2, firePoint3.position, firePoint3.rotation);
        }
        if(GunLevel >= 2)
        {
          Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);
          Instantiate(bulletPrefab, firePoint5.position, firePoint5.rotation);
          Instantiate(bulletPrefab, firePoint6.position, firePoint6.rotation);
          Instantiate(bulletPrefab, firePoint7.position, firePoint7.rotation);
        }
      }
      GetComponent<AudioSource>().Play();
    }
    #region 電力變動
    //耗電力
    public void CostEnergy(int cost)
    {
      currentEnergy -= cost;
      if(currentEnergy <= 0)
      {
        currentEnergy = 0;
      }
        energyBar.SetEnergy(currentEnergy);
    }
    //回電力
    public void RecoverEnergy(int cover)
    {
      currentEnergy += cover;
      if(currentEnergy >= maxEnergy)
      {
        currentEnergy = maxEnergy;
      }
      energyBar.SetEnergy(currentEnergy);
    }
    #endregion 
  }
}


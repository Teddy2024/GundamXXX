using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Teddy
{
  ///<summary>
  ///玩家生命
  ///</summary>
  public class Health : MonoBehaviour
  {
    [Header("生命值")]
    public int maxHealth = 5;
    public int currentHealth = 0;
    [SerializeField] private Image[] hearts;
    Vector2 initialPosition;
    private Animator anim;
    [Header("無敵")]
    public bool isInvulnerable = false;
    //盾牌
    GameObject shield;
      
    // Start is called before the first frame update
    private void Awake()
    {
        initialPosition = transform.position;
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        shield = transform.Find("Shield").gameObject;
        DeactivateShield();
    }

    private void Update() 
    {
      HealthBarSet();
    }

    #region 盾牌處理
    void ActivateShield()
    {
      shield.SetActive(true);
    }
    void DeactivateShield()
    {
      shield.SetActive(false);
    }
      
    public bool HasShield()
    {
      return shield.activeSelf;
    }
    #endregion


    public void TakeDamage(int damage)
    {
        if(isInvulnerable)
        {
            return;
        }
        if(HasShield())
        {
          shield.SetActive(false);  
          return;
        }
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            ResetShip();
            return;
        }
        anim.SetTrigger("hurt");
    }

    void HealthBarSet()
    {
      for(int i = 0; i < hearts.Length; i++)
      {
        if(i < currentHealth)
        {
          hearts[i].color = new Color32(255, 255, 255, 255);
        }
        else
        {
          hearts[i].color = new Color32(90, 90, 90, 255);
        }
      }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
      if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
      {
        TakeDamage(1);
      }

      #region 強化物件碰撞
      Powerup powerUp = collision.GetComponent<Powerup>();
      if(powerUp)
      {
        Level.instance.AddScore(powerUp.scoreValue);
        if(powerUp.activateShield)
        {
          ActivateShield();
        }
        if(powerUp.addGuns)
        { 
          GetComponent<Fire>().GunLevel += 1;
          if(GetComponent<Fire>().GunLevel >=3)
          {
            GetComponent<Fire>().GunLevel = 3;
            GetComponent<Fire>().RecoverEnergy(100);
          }
        }
        Destroy(powerUp.gameObject);
      }
      #endregion


    }

    void Die()
    {
      Debug.Log("Die!!!!");
    }
    void ResetShip()
    {
      transform.position = initialPosition;
      DeactivateShield();
      GetComponent<Fire>().GunLevel = 0;
      currentHealth = 5;
      Level.instance.ResetLevel();
    }

  }
}
  



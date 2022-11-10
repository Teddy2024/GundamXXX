using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Teddy
{
    ///<summary>
    ///子彈
    ///</summary>
    public class Bullet : MonoBehaviour
    {
        #region 變數
        public float speed = 1f;
        public int damage = 1;
        public float bulletRemain = 2f;
        public Rigidbody2D rb;
        public GameObject hitEffect;
        #endregion

        
        // Start is called before the first frame update
        void Start()
        {
            rb.velocity = transform.up * speed;
            Destroy(gameObject, bulletRemain); 
            DontDestroyOnLoad(gameObject);
        }
        private void OnTriggerEnter2D(Collider2D hitInfo) 
        {
            //Debug.Log(hitInfo.name);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);
            Teddy.Health player = hitInfo.GetComponent<Teddy.Health>();
            if(player != null)
            {
                player.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}


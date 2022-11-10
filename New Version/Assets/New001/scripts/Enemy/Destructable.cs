using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Teddy
{
    ///<summary>
    ///摧毀控制器
    ///</summary>
    public class Destructable : MonoBehaviour
    {
        public GameObject explosion;
        bool canDestroyed = false;
        public int scoreValue = 10;
        // Start is called before the first frame update
        void Start()
        {
            //計算剩餘敵人數
            Teddy.Level.instance.AddDestructable();
        }

        // Update is called once per frame
        void Update()
        {
            if(transform.position.x < -10)
            {
                DestroyDestructable();
            }
            if(transform.position.x < 10f && !canDestroyed)
            {
                canDestroyed = true;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision) 
        {
            if(!canDestroyed)
            {
                return;
            }
            Teddy.Bullet bullet = collision.GetComponent<Teddy.Bullet>();
            if(bullet != null)
            {
                Teddy.Level.instance.AddScore(scoreValue);
                Debug.Log("hit");
                DestroyDestructable();
            }
            if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                //Destroy(gameObject);
                DestroyDestructable();
            }
        }
        void DestroyDestructable()
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Teddy.Level.instance.RemoveDestructable();
            Destroy(gameObject);
        }
    }
}


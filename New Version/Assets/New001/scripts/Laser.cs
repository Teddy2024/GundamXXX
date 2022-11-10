using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Teddy
{
    public class Laser : MonoBehaviour
    {
        public int damage = 1;
        public float laserRemain = 2f;
        
        void Start()
        {
            Destroy(gameObject, laserRemain);
        }


        private void OnTriggerEnter2D(Collider2D hitInfo) 
        {
            //Debug.Log(hitInfo.name);
            Teddy.Health player = hitInfo.GetComponent<Teddy.Health>();
            if(player != null)
            {
                player.TakeDamage(damage);
            }
        }
            
        
    }
}


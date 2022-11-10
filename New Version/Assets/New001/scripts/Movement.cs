using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Teddy
{
    ///<summary>
    ///飛機移動
    ///</summary>
    public class Movement : MonoBehaviour
    {
        [Header("速度與加速")]
        public float moveSpeed = 5f;
        public float upSpeed = 1.5f;
        public Rigidbody2D rb;
        private Animator anim;
        Vector2 movement;
        bool speedUp;

        private void Awake() 
        {
            anim = GetComponent<Animator>();
        }
        
        void Update()
        {
            speedUp = Input.GetKey(KeyCode.K);
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if(Input.GetKey(KeyCode.K))
            {
                anim.SetBool("moving" , true);
            }
            else if(Input.GetAxisRaw("Horizontal") != 0)
            {
                anim.SetBool("moving" , true);
            }
            else if(Input.GetAxisRaw("Vertical") != 0)
            {
                anim.SetBool("moving" , true);
            }
            else
            {
                anim.SetBool("moving" , false);
            }
        }
        private void FixedUpdate() 
        {
            //移動
            Vector2 pos = transform.position;
            float moveAmount = moveSpeed * Time.fixedDeltaTime;
            if(speedUp)
            {
                moveAmount *= upSpeed;
            }
            #region 對角移動
            float moveMagnitude = Mathf.Sqrt(movement.x * movement.x + movement.y * movement.y);
            if(moveMagnitude > moveAmount)
            {
                float ratio = moveAmount / moveMagnitude;
                movement *= ratio;
            }
            #endregion 
            rb.MovePosition(rb.position + movement * moveAmount);
            if(pos.x <= -9)
            {
                pos.x = -9;
            }
            else if(pos.x >= 9)
            {
                pos.x = 9;
            }
            else if(pos.y >= 5)
            {
                pos.y = 5;
            }
            else if(pos.y <= -5)
            {
                pos.y = -5;
            }
            transform.position = pos;
        }
    }
}


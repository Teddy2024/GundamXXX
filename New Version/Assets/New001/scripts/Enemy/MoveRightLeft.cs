using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Teddy
{
    ///<summary>
    ///向左移動
    ///</summary>
    public class MoveRightLeft : MonoBehaviour
    {
        public float moveSpeed = 5f;
        
        private void FixedUpdate() 
        {
            Vector2 pos = transform.position;
            pos.x -= moveSpeed * Time.fixedDeltaTime;
            transform.position = pos;
        }
    } 
}

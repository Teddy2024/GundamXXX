using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Teddy
{
    ///<summary>
    ///搖晃移動
    ///</summary>
    public class MoveSin : MonoBehaviour
    {
        float sinCenterY;
        [Header("震幅")]
        public float amplitude = 2f;
        [Header("頻率")]
        public float frequency = 2f;
        [Header("鏡像")]
        public bool inverted = false;

        // Start is called before the first frame update
        void Start()
        {
          sinCenterY = transform.position.y;
        }

        private void FixedUpdate() 
        {
            Vector2 pos = transform.position;
            float sin = Mathf.Sin(pos.x * frequency) * amplitude;
            if(inverted)
            {
                sin *= -1;
            }
            pos.y = sinCenterY + sin;
            transform.position = pos;
        }
    } 
}


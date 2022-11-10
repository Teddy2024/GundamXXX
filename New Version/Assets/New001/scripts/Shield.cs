using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Teddy
{
  ///<summary>
  ///盾牌啟動
  ///</summary>
  public class Shield : MonoBehaviour
  {
    public SpriteRenderer spriteRenderer;
   
    // Update is called once per frame
    void Update()
    {
      if(spriteRenderer != null)
      {
        spriteRenderer.enabled = !spriteRenderer.enabled;
      }  
    }
  }
}


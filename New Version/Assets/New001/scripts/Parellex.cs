using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Teddy
{
  ///<summary>
  ///場景滾動
  ///</summary>
  public class Parellex : MonoBehaviour
  {
    private MeshRenderer meshRenderer;
    [Header("滾動速度")]
    public float animationSpeed = 0.05f;
    
    private void Awake() 
    {
      meshRenderer = GetComponent<MeshRenderer>();
    }
      
    // Update is called once per frame
    void Update()
    {
      meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
  }
}


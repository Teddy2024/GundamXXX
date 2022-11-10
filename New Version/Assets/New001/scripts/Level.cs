using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Teddy
{
  ///<summary>
  ///等級總控制器
  ///</summary>
  public class Level : MonoBehaviour
  {
    public static Level instance;
    //剩餘敵人數
    uint numDestructables = 0;
    bool startNextLevel = false;
    float nextLevelTimer = 3;
    //關卡
    string[] levels = {"Level1","Level2","Level3","Level4","Level5"};
    int currentLevel = 1;
    //分數
    int score = 0;
    TMPro.TextMeshProUGUI scoreText;

    private void Awake() 
    {
        if(instance == null)
        {
          instance = this;
          DontDestroyOnLoad(gameObject);
          scoreText = GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>();
        }
        else
        {
          Destroy(gameObject);
        }
    }
    
    public void AddScore(int amountToAdd)
    {
      score += amountToAdd;
      scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
      if(startNextLevel)
      {
        if(nextLevelTimer <= 0)
        {
          currentLevel++;
          if(currentLevel <= levels.Length)
          {
            string sceneName = levels[currentLevel -1];
            SceneManager.LoadSceneAsync(sceneName);
            Debug.Log("Next");
          }
          else
          {
            Debug.Log("GAMEOVER!!!!!");
          }
          nextLevelTimer = 5;
          startNextLevel = false;
        }
        else
        {
          nextLevelTimer -= Time.deltaTime;
        }
      }
    }
    //重製
    public void ResetLevel()
    {
      foreach (Teddy.Bullet b  in GameObject.FindObjectsOfType<Teddy.Bullet>())
      {
        Destroy(b.gameObject);
      }
      numDestructables = 0;
      score = 0;
      AddScore(score);
      string sceneName = levels[currentLevel -1];
      SceneManager.LoadScene(sceneName);
    }
    #region 敵人數控制關卡等級
    public void AddDestructable()
    {
        numDestructables++;
    }
    public void RemoveDestructable()
    {
        numDestructables --;
        if(numDestructables == 0)
        {
          startNextLevel = true;
        }
    }
    #endregion
  }
}


using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIPause = false;
    public GameObject pauseMenuUI;
    public void GamePause()
   {
    if (GameIPause)
    {
        Resume();
    }else
    {
        Paused();
    }
   }

   void Resume()
   {
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    GameIPause = false;
   }

   void Paused()
   {
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0f;
    GameIPause = true;
   }
   void ToMenu()
   {
    SceneManager.LoadSceneAsync(0);
    //pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    GameIPause = false;
   }
}

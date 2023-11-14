using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebriefWindows : MonoBehaviour
{

    public PlayerHP playerHP;
    public GameObject winWindow, loseWindow;
    void Update()
    {
        Death();
    }

    void Death()
    {
        if(playerHP.healthP <= 0)
        {
            loseWindow.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    

   
}

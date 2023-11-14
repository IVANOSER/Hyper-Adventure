using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    // Start is called before the first frame update
    public float healthP, maxHealthP = 100f;
    public Slider healthBar;
    void Start()
    {
         healthP = maxHealthP;
    }
    // Update is called once per frame
    void Update()
    {       
        healthBar.value = healthP;
    }
    

}

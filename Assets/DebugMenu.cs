using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public void ClearData()
    {
        PlayerPrefs.DeleteAll ();
        SceneManager.LoadScene(0);
    }
}

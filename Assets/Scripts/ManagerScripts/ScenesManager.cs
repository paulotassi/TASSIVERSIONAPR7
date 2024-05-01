using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadStart()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Level 2.1");
    }


}

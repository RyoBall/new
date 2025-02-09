using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameenter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pressed()
    {
        if(levelmanager.nowlevel==0)
        SceneManager.LoadScene("level1");
        else
        SceneManager.LoadScene("level"+levelmanager.nowlevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

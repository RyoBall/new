using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endanim : MonoBehaviour
{
    public void end() 
    {
        levelmanager.nowlevel = 0;
        levelmanager.endgame = true;
        SceneManager.LoadScene("entergame");
    }
}

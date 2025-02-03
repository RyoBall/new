using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maskcontroller : MonoBehaviour
{
    private void Update()
    {
        if (((Player.Instance.stepturns == -1 || levelmanager.dicing || levelmanager.dicingchoose))) 
        {
            GetComponentInChildren<heimucontroller>(true).gameObject.SetActive(true);
        }
        else 
        {
            GetComponentInChildren<heimucontroller>(true).gameObject.SetActive(false);
        }
    }
}

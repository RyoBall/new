using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endbutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void function() 
    {
        if (Player.Instance.stepturns == 0) 
        {
            Debug.Log("end");
            Player.Instance.stepturns++;
            GetComponent<AudioSource>().Play();
        }
    }
}

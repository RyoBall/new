using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menucontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (levelmanager.endgame) 
        {
            GetComponent<AudioSource>().clip = null;
        }
    }
}

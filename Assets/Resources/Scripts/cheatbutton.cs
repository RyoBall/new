using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheatbutton : MonoBehaviour
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
        GameObject.Find("levelmanager").GetComponent<levelmanager>().win = true;
    }
}

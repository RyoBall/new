using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gettinggrivitation : MonoBehaviour
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
        Player.Instance.actions.Add("grivitation");
        Player.Instance.stepturns = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interfereenemy : enemy
{
    public override void Move(int step, int dir)
    {
        base.Move(step, dir);
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    public override void Update()
    {
        if (dead) 
        {
        GameObject.Find("step4").GetComponent<stepButton>().bestepped = false;   
        }
        else
        GameObject.Find("step4").GetComponent<stepButton>().bestepped = true;
        base.Update();
    }

    private new void Start()
    {
        health = 2;
        healthmax = 2;
    }
}

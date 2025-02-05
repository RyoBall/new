using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restoreenemy : enemy
{
    public bool restore;
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
       
        if (Player.Instance.stepturns == 5 && !dead) 
        {
            restore = true;
            notfinished = true;
        }
        animator.SetBool("restored", restore);
        base.Update();
    }

    private new void Start()
    {
        health = 6;
        healthmax = 6;
    }
    public void restored() 
    {
        health = healthmax;
        restore = false;
        notfinished=false;
    }
}

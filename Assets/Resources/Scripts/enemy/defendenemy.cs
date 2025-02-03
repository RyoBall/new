using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defendenemy : enemy
{
    public override void attackedfinished()
    {
        base.attackedfinished();
    }

    public override void deaded()
    {
        base.deaded();
    }

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
        if (health != healthmax && havedefense) 
        {
            health = healthmax;
            havedefense = false;
        }
        animator.SetBool("havedefend", havedefense);
        base.Update();
    }

    private new void Start()
    {
        health = 8;
        healthmax = 8;
        havedefense = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restoreenemy : enemy
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
        if (Player.Instance.stepturns==-1&&!dead)
        {
            health = healthmax;
        }
        base.Update();
    }

    private new void Start()
    {
        health = 6;
        healthmax = 6;
    }
}

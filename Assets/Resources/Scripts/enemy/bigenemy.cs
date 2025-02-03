using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigenemy :enemy
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
        base.Update();
    }

    private new void Start()
    {
        health = 10;
        healthmax = 10;
    }
}

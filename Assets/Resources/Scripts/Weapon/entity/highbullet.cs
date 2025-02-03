using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highbullet : EntityBase
{
    public override void function()
    {
        base.function();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    public override void Start()
    {
    
        range = 10;
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : EntityBase
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
        range = 4;
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
}

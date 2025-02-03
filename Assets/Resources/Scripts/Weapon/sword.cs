using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : WeaponBase
{
    public override void function()
    {
        base.function();
    }

    public override void pressed(string name)
    {
        base.pressed("sword");
    }

    // Start is called before the first frame update
    void Start()
    {
        step = 1;
        attack = 2;
        range = 2;
    }

    // Update is called once per frame
    void Update()
    {
        function();  
    }
}

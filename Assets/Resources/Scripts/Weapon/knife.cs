using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : WeaponBase
{
    public override void function()
    {
        base.function();
    }

    public override void pressed(string name)
    {
        base.pressed("knife");
    }

    // Start is called before the first frame update
    void Start()
    {
        step = 1;
        range = 1;
        attack = 4;
    }

    // Update is called once per frame
    void Update()
    {
        function();
    }

}

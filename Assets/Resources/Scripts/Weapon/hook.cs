using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook : WeaponBase
{
    public override void pressed(string name)
    {
        base.pressed("hook");
    }

    public override void shootfunction(GameObject Entity)
    {
        base.shootfunction(Entity);
    }

    // Start is called before the first frame update
    void Start()
    {
        step = 1;
        range = 5;
        attack = 1;
    }

    // Update is called once per frame
    void Update()
    {
       shootfunction(Entity);
    }
}

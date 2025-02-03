using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : WeaponBase
{


    public override void pressed(string name)
    {
        base.pressed("bow");
    }

    public override void shootfunction(GameObject Entity)
    {
        base.shootfunction(Entity);
    }

    // Start is called before the first frame update
    void Start()
    {
        range = 4;
        attack = 1;
        step = 1;
    }

    // Update is called once per frame
    void Update()
    {
        shootfunction(Entity);
    }
}

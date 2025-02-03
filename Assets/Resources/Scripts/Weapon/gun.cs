using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : WeaponBase
{
    public override void pressed(string name)
    {
        base.pressed("gun");
    }

    public override void shootfunction(GameObject Entity)
    {
        base.shootfunction(Entity);
    }

    // Start is called before the first frame update
    void Start()
    {
        step = 2;
        attack = 6;
        range = 5;
    }

    // Update is called once per frame
    void Update()
    {
        shootfunction(Entity);
    }
}

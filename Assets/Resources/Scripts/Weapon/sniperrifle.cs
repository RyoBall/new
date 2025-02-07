using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniperrifle : WeaponBase
{
    private void Start()
    {
        step = 4;
        attack = 10;
        range = 10;
    }
    public override void pressed(string name)
    {
        base.pressed("sniperrifle");
    }

    public override void shootfunction(GameObject Entity)
    {
        base.shootfunction(Entity);
    }
    private void Update()
    {
        shootfunction(Entity);
    }
}

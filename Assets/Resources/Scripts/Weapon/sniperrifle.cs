using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniperrifle : WeaponBase
{
    private void Start()
    {
        shooted = true;
        step = 3;
        attack = 10;
        range = 10;
    }
    public override void pressed(string name)
    {
        base.pressed("sniperrifle");
    }

    
    private void Update()
    {
        if (!start && Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
        {
            start = true;
            Player.Instance.sniper = true;
            Debug.Log("startsucceed");
        }
        shootfunction(Entity, Player.Instance.sniper);
    }

    public override void shootfunction(GameObject Entity, bool players)
    {
        base.shootfunction(Entity, players);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook : WeaponBase
{
    public override void pressed(string name)
    {
        base.pressed("hook");
    }

    public override void shootfunction(GameObject Entity,bool players)
    {
        base.shootfunction(Entity,players);
    }

    // Start is called before the first frame update
    void Start()
    {
        shooted = true;
        step = 1;
        range = 5;
        attack = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start && Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
        {
            start = true;
            Player.Instance.hook = true;
            Debug.Log("startsucceed");
        }
        shootfunction(Entity, Player.Instance.hook);
    }
}

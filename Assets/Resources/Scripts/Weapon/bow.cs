using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : WeaponBase
{


    public override void pressed(string name)
    {
        base.pressed("bow");
    }

    public override void shootfunction(GameObject Entity, bool players)
    {
        base.shootfunction(Entity, Player.Instance.bow);
    }



    // Start is called before the first frame update
    void Start()
    {
        shooted = true;
        range = 4;
        attack = 2;
        step = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start && Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
        {
            start = true;
            Player.Instance.bow = true;
            Debug.Log("startsucceed");
        }
        shootfunction(Entity,Player.Instance.bow);
    }
}

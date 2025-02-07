using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : WeaponBase
{
    public override void pressed(string name)
    {
        base.pressed("gun");
    }

    public override void shootfunction(GameObject Entity, bool players)
    {
        base.shootfunction(Entity, players);
    }



    // Start is called before the first frame update
    void Start()
    {
        shooted = true;
        step = 2;
        attack = 5;
        range = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start && Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
        {
            start = true;
            Player.Instance.gun = true;
            Debug.Log("startsucceed");
        }
        shootfunction(Entity, Player.Instance.gun);
    }
}

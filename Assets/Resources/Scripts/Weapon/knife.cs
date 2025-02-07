using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : WeaponBase
{
    public override void function(bool players)
    {
        base.function(players);
    }

    public override void pressed(string name)
    {
        base.pressed("knife");
    }

    // Start is called before the first frame update
    void Start()
    {
        attacked = true;
        step = 1;
        range = 1;
        attack = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start&& Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
        {
            start = true;
            Player.Instance.knife = true;
            Debug.Log("startsucceed");
        }
        function(Player.Instance.knife);
    }

}

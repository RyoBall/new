using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricburst : WeaponBase
{
    public int enemycheced;
    public override void function()
    {
        if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
        {
            if (!attacked)
            {
                for (int i = -range; i <= range; i++)
                {
                    if (GameObject.Find("platform" + (Player.Instance.currentposition + i * Player.Instance.facingdir)) == null)
                    {
                        break;
                    }//����Խ��
                    if (GameObject.Find("platform" + (Player.Instance.currentposition + i * Player.Instance.facingdir)).GetComponentInChildren<platformsEnemyChec>().EnemyHere)
                    {
                        GameObject.Find("platform" + (Player.Instance.currentposition + i * Player.Instance.facingdir)).GetComponentInChildren<platformsEnemyChec>().Damage = attack;
                        GameObject.Find("platform" + (Player.Instance.currentposition + i * Player.Instance.facingdir)).GetComponentInChildren<platformsEnemyChec>().PlayerAttackHere = true;
                        enemycheced++;
                    }
                }
                attacked = true;
            }
            if (attackedenemy == enemycheced)
            {
                Player.Instance.stepturns++;
               
            }
        }
    }

    public override void pressed(string name)
    {
        base.pressed("electricburst");
    }

    // Start is called before the first frame update
    void Start()
    {
        attack = 6;
        range = 2;
    }

    // Update is called once per frame
    void Update()
    {
        function();
    }
}

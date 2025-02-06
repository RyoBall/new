using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hugesword : WeaponBase
{
    public int enemycheced;//攻击范围内的敌人
    public override void function()
    {
        if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
        {
            if (!attacked) 
            {
                GetComponent<AudioSource>().Play();
                for (int i = 1; i <= range; i++)
            {
                if (GameObject.Find("platform" + (Player.Instance.currentposition + i * Player.Instance.facingdir)) == null)
                {
                    break;
                }//攻击越界
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
        base.pressed("hugesword");
    }



    // Start is called before the first frame update
    void Start()
    {
        attack = 5;
        range = 3;
        step = 3;
    }

    // Update is called once per frame
    void Update()
    {
        function();
    }
}

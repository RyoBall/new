using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricbaton : WeaponBase
{
    public override void pressed(string name)
    {
        base.pressed("electricbaton");
    }
    public void function() //到相应步骤要执行的函数
    {
        if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
        {
            if (!start) 
            {
                Player.Instance.baton = true;
                start = true;
            }
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
                        GameObject.Find("platform" + (Player.Instance.currentposition + i * Player.Instance.facingdir)).GetComponentInChildren<platformsEnemyChec>().haselectric=true;
                        GameObject.Find("platform" + (Player.Instance.currentposition + i * Player.Instance.facingdir)).GetComponentInChildren<platformsEnemyChec>().PlayerAttackHere = true;
                        break;
                    }
                }
                attacked = true;
            }
            if (attackedenemy > 0)
            {
                Player.Instance.stepturns++;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        attacked = true;
        attack = 2;
        range = 1;
        step = 1;   
    }

    // Update is called once per frame
    void Update()
    {
        function();
    }
}

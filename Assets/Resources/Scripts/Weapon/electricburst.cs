using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricburst : WeaponBase
{
    public int enemycheced;
    public bool haveattacked;
    public void function()
    {
        if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
        {
            if (!attacked)
            {
                Debug.Log("attack");
                GetComponent<AudioSource>().Play();
                for (int i = -range; i <= range; i++)
                {
                    if (GameObject.Find("platform" + (Player.Instance.currentposition + i)) == null)
                    {
                        Debug.Log("over"+ (Player.Instance.currentposition + i));
                        continue;
                    }//¹¥»÷Ô½½ç
                    if (GameObject.Find("platform" + (Player.Instance.currentposition + i)).GetComponentInChildren<platformsEnemyChec>().EnemyHere)
                    {
                        Debug.Log("attack"+ (Player.Instance.currentposition + i));
                        GameObject.Find("platform" + (Player.Instance.currentposition + i)).GetComponentInChildren<platformsEnemyChec>().Damage = attack;
                        GameObject.Find("platform" + (Player.Instance.currentposition + i)).GetComponentInChildren<platformsEnemyChec>().PlayerAttackHere = true;
                        enemycheced++;
                    }
                }
                attacked = true;
                haveattacked = true;
            }
            if (attackedenemy == enemycheced&&haveattacked)
            {
                Debug.Log("goon");  
                levelmanager.stepgo();
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
        attacked = true;
        attack = 6;
        range = 2;
        step = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start && Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
        {
            start = true;
            Player.Instance.burst = true;
            Debug.Log("startsucceed");
        }
        function();
    }
}

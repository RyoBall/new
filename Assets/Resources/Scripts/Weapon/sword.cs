using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using static UnityEditor.Experimental.GraphView.GraphView;
#endif
public class sword : WeaponBase
{
    public int enemycheced;
    
    public override void function(bool players)
    {
            if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
            {
                if (!attacked)
                {
                    GetComponent<AudioSource>().Play();
                    levelmanager.stepgo();
                    for (int i = 1; i <= range; i++)
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
            }
    }

    public override void pressed(string name)
    {
        base.pressed("sword");
    }

    // Start is called before the first frame update
    void Start()
    {
        step = 1;
        attack = 3;
        range = 2;
        attacked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start && Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
        {
            start = true;
            Player.Instance.sword=true;
            Debug.Log("startsucceed");
        }
        function(Player.Instance.sword);  
    }
}

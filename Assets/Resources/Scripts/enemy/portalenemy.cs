using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalenemy : enemy
{
    public int lastturn;//在敌人视角记录上一回合，判断用
    public bool portalstart;
    public bool portaled;
    public override void Move(int step, int dir)
    {
        base.Move(step, dir);
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    public override void Update()
    {
       
        if (Player.Instance.stepturns==-1&&!dead) 
        {
            notfinished = true;
            portaled = false;
        }
        if (Player.Instance.stepturns==5&&!dead&&!portaled) 
        {
            portalstart = true;
            portaled=true;
        }
        animator.SetBool("portalstart", portalstart);
        animator.SetBool("attacked", attacked);
        base.Update();
    }

    private new void Start()
    {
        lasthealth = health;
        animator = GetComponent<Animator>();
        health = 2;
        healthmax = 2;
        lastturn=Player.Instance.turn;
    }
    public void portal() 
    {
        int targetpositoin;
        while (true)
        {
            targetpositoin = Random.Range(1, GameObject.Find("levelmanager").GetComponent<levelmanager>().maprange + 1);
            if (GameObject.Find("platform" + targetpositoin).GetComponentInChildren<platformsEnemyChec>().EnemyHere || GameObject.Find("platform" + targetpositoin).GetComponentInChildren<platformsEnemyChec>().PlayerHere)
            {
                ;
            }
            else
                break;
        }
        currentposition = targetpositoin;
        transform.position = new Vector3(GameObject.Find("platform" + targetpositoin).transform.position.x, transform.position.y, transform.position.z);
        portalstart=false;
    }
    public void portalend() 
    {
        notfinished = false;
    }
}

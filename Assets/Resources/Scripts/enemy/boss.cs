using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : enemy
{
    public enum mode{defend,interfere,portal,restore};
    public mode currentmode;
    public bool modeused;
    public bool healththisturn;
    public bool interfereing;
    public int lastturn;
    public bool defend;
    public bool interfere;
    public bool restore;
    public bool portal;
    public bool act;
    public bool interfereset;
    public override void Move(int step, int dir)
    {
        base.Move(step, dir);
    }

    public new void OnMouseDown()
    {
        if (levelmanager.deathnotechoosing)
        {
            levelmanager.deathnotechoosing = false;
            Player.Instance.stepturns++;
        }
        if (levelmanager.changerchoosing)
        {
            Vector3 trans = transform.position;
            int position = currentposition;//¥Ê¥¢µ±«∞Œª÷√
            currentposition = Player.Instance.currentposition;
            transform.position = Player.Instance.transform.position;
            Player.Instance.currentposition = position;
            Player.Instance.transform.position = trans;
            Player.Instance.stepturns++;
        }

    }

    public override void Update()
    {
        animator.SetBool("havedefend", havedefense);
        animator.SetBool("interfere", interfere);
        animator.SetBool("portal", portal);
        animator.SetBool("restore", restore);
        animator.SetBool("defend", defend);
        if (lastturn != Player.Instance.turn) 
        {
            notfinished = true;
            act = false;
            lastturn = Player.Instance.turn;
            interfereset = false;
        }
        if (Player.Instance.stepturns==5&&!act)
        {
            if (!havedefense)
                currentmode = (mode)Random.Range(0, 4);
            else
                currentmode = (mode)Random.Range(1, 4);
            act = true;
            switch (currentmode) 
            {
                case mode.defend:
                    defend = true;
                    havedefense = true;
                    interfereing = false;
                    break;
                case mode.portal:
                    portal = true;
                    interfereing = false;
                    break;
                case mode.restore:
                    restore = true;
                    interfereing = false;
                    break;
                case mode.interfere:
                    interfereing = true;
                    interfere = true;
                    break;
            }
        }
        if (health != healthmax && havedefense)
        {
            health = healthmax;
            havedefense = false;
        }
        if (interfereing&&!interfereset)
        {
            GameObject.Find("step4").GetComponent<stepButton>().bestepped = true;
            GameObject.Find("step3").GetComponent<stepButton>().bestepped = true;
            interfereset = true;
        }
        else if(!interfereing&&!interfereset)
        {
            GameObject.Find("step3").GetComponent<stepButton>().bestepped = false;
            GameObject.Find("step4").GetComponent<stepButton>().bestepped = false;   
            interfereset = true;
        }
        base.Update();
    }

    // Start is called before the first frame update
    new void Start()
    {
            health = 40;
            healthmax = 40; 
            lasthealth = health;
        notfinished = true;
    }
    public void portalstart() 
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
    }
    public void restorestart() 
    {
            health += 6;
       if (health > healthmax) 
            {
            health= healthmax;
            }
    }
    public void finish() 
    {
        restore = false;
        portal = false;
        interfere = false;
        defend = false;
        notfinished= false;
    }
   
}

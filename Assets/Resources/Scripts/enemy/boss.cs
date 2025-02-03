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
    public override void Move(int step, int dir)
    {
        base.Move(step, dir);
    }

    public new void OnMouseDown()
    {
        if (levelmanager.deathnotechoosing)
        {
            Debug.Log("noeffect");
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
        if (lastturn != Player.Instance.turn)
        {
            lastturn = Player.Instance.turn;
            currentmode= (mode)Random.Range(0, 4);
            switch (currentmode) 
            {
                case mode.defend:
                    havedefense = true;
                    interfereing = false;
                    break;
                case mode.portal:
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
                    interfereing = false;
                    break;
                case mode.restore:
                    health += 6;
                    if (health > healthmax) 
                    {
                        health= healthmax;
                    }
                    interfereing = false;
                    break;
                case mode.interfere:
                    interfereing = false;
                    break;
            }
        }
        if (interfereing)
        {
            GameObject.Find("step4").GetComponent<stepButton>().bestepped = true;
            GameObject.Find("step3").GetComponent<stepButton>().bestepped = true;
        }
        else 
        {
            GameObject.Find("step3").GetComponent<stepButton>().bestepped = false;
            GameObject.Find("step4").GetComponent<stepButton>().bestepped = false;   
        }
        base.Update();
    }

    // Start is called before the first frame update
    new void Start()
    {
            health = 40;
            healthmax = 40;
    }

   
}

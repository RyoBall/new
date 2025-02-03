using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : WeaponBase
{
    public override void pressed(string name)
    {
        if (Player.Instance.Objectused.Contains("spring"))
        {
            GetComponentInParent<stepButton>().havestep = false;
            GetComponentInParent<stepButton>().stepname = null;
            GetComponentInParent<stepButton>().stepenough = false;
            GetComponentInParent<stepButton>().choiceclear = false;
            Debug.Log("used!");
        }
        else
        {
            base.pressed("spring");
            Player.Instance.Objectused.Add("spring");
        }
    }

    public int targetposition;
    // Start is called before the first frame update
    void Start()
    {
        step = 1;
        range = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
        {
            if (Player.Instance.facingdir > 0)
            {
                for (int i = Player.Instance.currentposition + range; i > Player.Instance.currentposition + range; i--)
                {
                    if (GameObject.Find("platform" + i) != null && GameObject.Find("platform" + i).GetComponentInChildren<platformsEnemyChec>().EnemyHere == false)
                    {
                        targetposition = i;
                        break;
                    }
                }
            }
            else
            {
                for (int i = Player.Instance.currentposition - range; i < Player.Instance.currentposition + range; i++)
                {
                    if (GameObject.Find("platform" + i) != null && GameObject.Find("platform" + i).GetComponentInChildren<platformsEnemyChec>().EnemyHere == false)
                    {
                        targetposition = i;
                        break;
                    }
                }
            }
            if (targetposition == 0)
            {
                Debug.Log("spring no target");
                Player.Instance.stepturns++;
                if (Player.Instance.stepturns == 5)
                    Player.Instance.stepturns = -1;
            }
            else
            {
                Player.Instance.rb.velocity = new Vector2(10 * Player.Instance.facingdir, 0);
                if ((Player.Instance.transform.position.x >= GameObject.Find("platform" + targetposition).transform.position.x && Player.Instance.facingdir > 0) || (Player.Instance.transform.position.x <= GameObject.Find("platform" + targetposition).transform.position.x && Player.Instance.facingdir < 0))
                {
                    Player.Instance.rb.velocity = Vector2.zero;
                    Player.Instance.currentposition += targetposition * Player.Instance.facingdir;
                    Player.Instance.stepturns++;
                    
                }
            }
        }
    }
}

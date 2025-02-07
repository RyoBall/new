using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dash : WeaponBase
{
    public int targetposition;
    public int movesteps;
    public int times = 0;
    public int lasttimes = -1;
    public bool setdashstart;
    public override void function()
    {
        if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
        {
            if (!setdashstart) 
            {
                Player.Instance.dashed = false;
                setdashstart = true;
            }
            Player.Instance.rb.velocity = new Vector2(10 * Player.Instance.facingdir, 0);
            GetComponent<AudioSource>().Play();
            if (lasttimes != times)
            {
                lasttimes = times;
                Player.Instance.dashed = false;
            }
            if (time != 3) 
            {
                if (Player.Instance.facingdir > 0)
                {
                    for (int i = Player.Instance.currentposition + 1; i > Player.Instance.currentposition; i--)
                    {
                        if (GameObject.Find("platform" + i) != null)
                        {
                            targetposition = i;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = Player.Instance.currentposition - 1; i < Player.Instance.currentposition; i++)
                    {
                        if (GameObject.Find("platform" + i) != null)
                        {
                            targetposition = i;
                            break;
                        }
                    }
                }
                if (targetposition == 0)
                {
                    Debug.Log("dash no target");
                    Player.Instance.stepturns++;
                    if (Player.Instance.stepturns == 5)
                    Player.Instance.stepturns = -1;
                }
                else
                {
                    Player.Instance.dashtargetposition = targetposition;
                    if ((Player.Instance.transform.position.x >= GameObject.Find("platform" + targetposition).transform.position.x && Player.Instance.facingdir > 0) || (Player.Instance.transform.position.x <= GameObject.Find("platform" + targetposition).transform.position.x && Player.Instance.facingdir < 0))
                    {
                        Player.Instance.currentposition = targetposition;
                        times++;
                        Debug.Log("move once");
                    }
                }
            }
            if (times == 3) 
            {
                Player.Instance.rb.velocity = Vector2.zero;
                    Debug.Log("end");
                    Player.Instance.stepturns++;
            }
        }
    }

    public override void pressed(string name)
    {
        if(GameObject.Find("platform" + (Player.Instance.stepposition[GetComponentInParent<stepButton>().stepturns-1] + range * Player.Instance.facingdir)) == null) 
        {
            GetComponentInParent<stepButton>().havestep = false;
            GetComponentInParent<stepButton>().stepname = null;
            GetComponentInParent<stepButton>().stepenough = false;
            GetComponentInParent<stepButton>().choiceclear = false;
            GetComponentInParent<stepButton>().pressed = false;
            Debug.Log("no target");
        }
        else 
        {
            if (GameObject.Find("platform" + (Player.Instance.stepposition[GetComponentInParent<stepButton>().stepturns-1] + range * Player.Instance.facingdir)).GetComponentInChildren<platformsEnemyChec>().EnemyHere)
            {
                GetComponentInParent<stepButton>().havestep = false;
                GetComponentInParent<stepButton>().stepname = null;
                GetComponentInParent<stepButton>().stepenough = false;
                GetComponentInParent<stepButton>().choiceclear = false;
                Debug.Log("enemy here");
            }
            else 
            {
                if (GetComponentInParent<stepButton>().stepturns != 4) 
                {
                for (int i = GetComponentInParent<stepButton>().stepturns; i <= 3; i++)
                {
                    Player.Instance.stepposition[i]+=Player.Instance.stepfacingdir[GetComponentInParent<stepButton>().stepturns]*3;
                }
                }
                base.pressed("dash");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        range = 3;
        step = 2;
        attack =4;
    }

    // Update is called once per frame
    void Update()
    {
        function();
    }
}

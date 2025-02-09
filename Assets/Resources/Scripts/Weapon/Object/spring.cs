using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spring : WeaponBase
{
    public GameObject tip;
    public bool springed;
    public override void pressed(string name)
    {
        if (Player.Instance.Objectused.Contains("spring")) 
        {
            GetComponentInParent<stepButton>().havestep = false;
            GetComponentInParent<stepButton>().stepname = null;
            GetComponentInParent<stepButton>().pressed = false;
            GetComponentInParent<stepButton>().stepenough = false;
            GetComponentInParent<stepButton>().choiceclear = false;
            GetComponentInParent<stepButton>().Grparrow.SetActive(false);
            GetComponentInParent<stepButton>().Grpweapon.SetActive(false);
            Debug.Log("used!");
        }
        /*else 
        {
            if (GameObject.Find("platform" + (Player.Instance.stepposition[GetComponentInParent<stepButton>().stepturns - 1] + range * Player.Instance.facingdir)) == null)
            {
                GetComponentInParent<stepButton>().havestep = false;
                GetComponentInParent<stepButton>().stepname = null;
                GetComponentInParent<stepButton>().pressed = false;
                GetComponentInParent<stepButton>().stepenough = false;
                GetComponentInParent<stepButton>().choiceclear = false;
                GetComponentInParent<stepButton>().Grparrow.SetActive(false);
                GetComponentInParent<stepButton>().Grpweapon.SetActive(false);
                Debug.Log("no target");
            }
            else
            {
                /*if (GameObject.Find("platform" + (Player.Instance.stepposition[GetComponentInParent<stepButton>().stepturns-1] + range * Player.Instance.facingdir)).GetComponentInChildren<platformsEnemyChec>().EnemyHere)
                {
                    GetComponentInParent<stepButton>().havestep = false;
                    GetComponentInParent<stepButton>().stepname = null;
                    GetComponentInParent<stepButton>().pressed = false;
                    GetComponentInParent<stepButton>().stepenough = false;
                    GetComponentInParent<stepButton>().choiceclear = false;
                    GetComponentInParent<stepButton>().Grparrow.SetActive(false);
                    GetComponentInParent<stepButton>().Grpweapon.SetActive(false);
                    Debug.Log("enemy here");
                }*/
        base.pressed("spring");
        if (GetComponentInParent<stepButton>().stepname != null)
        {
            if (GetComponentInParent<stepButton>().stepturns != 4)
            {
                for (int i = GetComponentInParent<stepButton>().stepturns - 1; i <= 3; i++)
                {
                    Player.Instance.stepposition[i] += Player.Instance.stepfacingdir[GetComponentInParent<stepButton>().stepturns] * 2;
                }
            }
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
        if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns&&!springed)
        {
            springed = true;
            if (Player.Instance.facingdir > 0)
            {
                if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
                {
                    Player.Instance.turnvector = 1;
                    Player.Instance.targetposition = Player.Instance.currentposition + 2;
                    Player.Instance.move = true;
                }
            }
            else
            {
                for (int i = Player.Instance.currentposition-range; i < Player.Instance.currentposition; i++)
                {
                    if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
                    {
                        Player.Instance.turnvector = -1;
                        Player.Instance.targetposition = Player.Instance.currentposition -2;
                        Player.Instance.move = true;
                    }
                }
            }
        }
    }
}

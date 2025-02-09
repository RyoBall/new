using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathnote : WeaponBase
{
    public GameObject target;
    public bool tip;
    public override void pressed(string name)
    {
        if (Player.Instance.Objectused.Contains("deathnote"))
        {
            GetComponentInParent<stepButton>().havestep = false;
            GetComponentInParent<stepButton>().stepname = null;
            GetComponentInParent<stepButton>().stepenough = false;
            GetComponentInParent<stepButton>().choiceclear = false;
            GetComponentInParent<stepButton>().pressed = false;
            GetComponentInParent<stepButton>().Grparrow.SetActive(false);
            GetComponentInParent<stepButton>().Grpweapon.SetActive(false);
            Debug.Log("used!");
        }
        else
        {
            base.pressed("deathnote");
            Player.Instance.Objectused.Add("deathnote");
        }
    }

    public int targetposition;
    // Start is called before the first frame update
    void Start()
    {
        step = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
        {
            if (target == null) 
            {
                if (!tip) 
                {
                    Debug.Log("choose one");
                    levelmanager.deathnotechoosing = true;
                    tip= true;
                }
            }   
        }
    }
}

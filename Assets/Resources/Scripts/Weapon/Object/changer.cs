using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changer : WeaponBase 
{ 
    public GameObject target;
    public bool tip;
    public override void pressed(string name)
    {
        if (Player.Instance.Objectused.Contains("changer"))
        {
            GetComponentInParent<stepButton>().havestep = false;
            GetComponentInParent<stepButton>().stepname = null;
            GetComponentInParent<stepButton>().stepenough = false;
            GetComponentInParent<stepButton>().choiceclear = false;
            Debug.Log("used!");
        }
        else
        {
            base.pressed("changer");
            if(GetComponentInParent<stepButton>().stepname != null)
            Player.Instance.Objectused.Add("changer");
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
                    GetComponent<AudioSource>().Play();
                    Debug.Log("choose one");
                    levelmanager.changerchoosing = true;
                    tip = true;
                }
            }
        }
    }
}

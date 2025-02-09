using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charger : WeaponBase
{
    public override void pressed(string name)
    {
        if (Player.Instance.Objectused.Contains("charger"))
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
            base.pressed("charger");
            Player.Instance.Objectused.Add("charger");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns && !used)
        {
            Player.Instance.health++;
            Player.Instance.stepturns++;
            used = true;
        }
    }
}

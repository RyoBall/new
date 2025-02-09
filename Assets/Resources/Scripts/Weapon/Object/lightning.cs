using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : WeaponBase
{
    public override void pressed(string name)
    {
        if (Player.Instance.Objectused.Contains("lightning"))
        {
            GetComponentInParent<stepButton>().havestep = false;
            GetComponentInParent<stepButton>().stepname = null;
            GetComponentInParent<stepButton>().stepenough = false;
            GetComponentInParent<stepButton>().choiceclear = false;
            Debug.Log("used!");
        }
        else
        {
            base.pressed("lightning");
            if (GetComponentInParent<stepButton>().stepname != null)
                Player.Instance.Objectused.Add("lightning");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<stepButton>().stepturns == Player.Instance.stepturns&&!used) 
        {
            for(int i = GetComponentInParent<stepButton>().stepturns + 1; i <= 4; i++) 
            {
                if (Player.Weaponbag.Contains(GameObject.Find("step" + i).GetComponent<stepButton>().stepname)) 
                {
                    GameObject.Find("step" + i).GetComponentInChildren<WeaponBase>().attack += 2;
                    break;
                }
            }
            used = true;
            levelmanager.stepgo();
        }
    }
}

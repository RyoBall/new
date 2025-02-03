using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dice : WeaponBase
{
    public override void pressed(string name)
    {
        if (Player.Instance.Objectused.Contains("dice"))
        {
            GetComponentInParent<stepButton>().havestep = false;
            GetComponentInParent<stepButton>().stepname = null;
            GetComponentInParent<stepButton>().stepenough = false;
            GetComponentInParent<stepButton>().choiceclear = false;
            Debug.Log("used!");
        }
        else
        {
            base.pressed("dice");
            Player.Instance.Objectused.Add("dice");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        step = 2;
    }
    private void Update()
    {
        if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns&&!used) 
        {
            levelmanager.dicingchoose = true;
            getObjectController.dicechoiceGenerate = false;
            used=true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grivitation : WeaponBase
{
    public int enemycheced;
    public override void pressed(string name)
    {
        if (Player.Instance.Objectused.Contains("grivitation"))
        {
            GetComponentInParent<stepButton>().havestep = false;
            GetComponentInParent<stepButton>().stepname = null;
            GetComponentInParent<stepButton>().stepenough = false;
            GetComponentInParent<stepButton>().choiceclear = false;
            Debug.Log("used!");
        }
        else
        {
            base.pressed("grivitation");
            Player.Instance.Objectused.Add("grivitation");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        range = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns && !used) 
        {
            int leftchec = 0;//在左边吸引的敌人个数
            int rightchec = 0;//在右边吸引的敌人个数
            for(int i = 1; i <= range; i++) 
            {
                for(int j=0;j< GameObject.Find("levelmanager").GetComponent<levelmanager>().enemys.Count; j++) 
                {
                    if (GameObject.Find("levelmanager").GetComponent<levelmanager>().enemys[j].GetComponent<enemy>().currentposition == Player.Instance.currentposition + i) 
                    {
                        GameObject.Find("levelmanager").GetComponent<levelmanager>().enemys[j].GetComponent<enemy>().ismoving = true;
                        GameObject.Find("levelmanager").GetComponent<levelmanager>().enemys[j].GetComponent<enemy>().dir = -1;
                        GameObject.Find("levelmanager").GetComponent<levelmanager>().enemys[j].GetComponent<enemy>().step = GameObject.Find("levelmanager").GetComponent<levelmanager>().enemys[j].GetComponent<enemy>().currentposition-Player.Instance.currentposition-1-rightchec;
                        rightchec++;
                    }
                }
                for (int j = 0; j < GameObject.Find("levelmanager").GetComponent<levelmanager>().enemys.Count; j++)
                {
                    if (GameObject.Find("levelmanager").GetComponent<levelmanager>().enemys[j].GetComponent<enemy>().currentposition == Player.Instance.currentposition - i)
                    {
                        GameObject.Find("levelmanager").GetComponent<levelmanager>().enemys[j].GetComponent<enemy>().ismoving = true;
                        GameObject.Find("levelmanager").GetComponent<levelmanager>().enemys[j].GetComponent<enemy>().dir = 1;
                        GameObject.Find("levelmanager").GetComponent<levelmanager>().enemys[j].GetComponent<enemy>().step = -GameObject.Find("levelmanager").GetComponent<levelmanager>().enemys[j].GetComponent<enemy>().currentposition + Player.Instance.currentposition - 1 - leftchec;
                        leftchec++;
                    }
                }
            }
            used = true;
        }
    }
}

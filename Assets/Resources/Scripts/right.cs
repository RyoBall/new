using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class right : MonoBehaviour
{
    public bool set;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        function();
    }
    public void function() //到相应步骤要执行的函数
    {
        if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
        {
            if (!set)
            {
                Player.Instance.move = true;
                set = true;
            }
            Player.Instance.turnvector = 1;
            Player.Instance.targetposition = Player.Instance.currentposition + 1;
            if (GameObject.Find("platform" + Player.Instance.targetposition) == null || GameObject.Find("platform" + Player.Instance.targetposition).GetComponentInChildren<platformsEnemyChec>().EnemyHere)
            {
                Player.Instance.targetposition = Player.Instance.currentposition;
            }
        }
    }
    public void pressed() //按下时要执行的函数
    {
        if (GetComponentInParent<stepButton>().stepname == "right")
        {
            GetComponentInParent<stepButton>().choiceclear = false;
            GetComponentInParent<stepButton>().pressed = false;
            GetComponentInParent<stepButton>().Grparrow.SetActive(false);
            GetComponentInParent<stepButton>().Grpweapon.SetActive(false);
            Destroy(transform.parent.gameObject);
        }
        else 
        {
        GetComponentInParent<stepButton>().havestep = true;
        GetComponentInParent<stepButton>().pressed = false;
        GetComponentInParent<stepButton>().stepname = "right";
        GetComponentInParent<stepButton>().choiceclear = false;
        GetComponentInParent<stepButton>().Grparrow.SetActive(false);
        GetComponentInParent<stepButton>().Grpweapon.SetActive(false);
        GetComponentInParent<stepButton>().transform.Find("normalbutton").GetComponent<Animator>().SetBool("isSelected", false); ;
            for (int i = GetComponentInParent<stepButton>().stepturns-1; i <= 3; i++)
            {
                Player.Instance.stepposition[i]++;
            }
            for (int i = GetComponentInParent<stepButton>().stepturns-1; i <= 3; i++)
            {
                if (GameObject.Find("step" + (i+1)).GetComponent<stepButton>().stepname != "left")
                    Player.Instance.stepfacingdir[i] = 1;
                else
                    break;
            }
        }
        Destroy(gameObject);
    }
}

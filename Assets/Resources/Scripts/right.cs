using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class right : MonoBehaviour
{
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
            Player.Instance.turnvector = 1;
            Player.Instance.targetposition = Player.Instance.currentposition + 1;
            Player.Instance.move = true;
        }
    }
    public void pressed() //按下时要执行的函数
    {
        GetComponentInParent<stepButton>().havestep = true;
        GetComponentInParent<stepButton>().pressed = false;
        GetComponentInParent<stepButton>().stepname = "right";
        GetComponentInParent<stepButton>().choiceclear = false;
        GetComponentInParent<stepButton>().Grparrow.SetActive(false);
        GetComponentInParent<stepButton>().Grpweapon.SetActive(false);
        GetComponentInParent<stepButton>().transform.Find("normalbutton").GetComponent<Animator>().SetBool("isSelected", false); ;
        if (GetComponentInParent<stepButton>().stepturns != 4) 
        {
            for(int i= GetComponentInParent<stepButton>().stepturns; i <= 3; i++) 
            {
                Player.Instance.stepposition[i]++;
                Player.Instance.stepfacingdir[i]=1;
            }
        }
        Destroy(gameObject);
    }
}

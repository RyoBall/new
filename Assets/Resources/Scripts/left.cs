using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left : MonoBehaviour
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
            Player.Instance.facingdir = -1;
            int targetposition=Player.Instance.currentposition-1;
            if (GameObject.Find("platform" + targetposition) == null || GameObject.Find("platform" + targetposition).GetComponentInChildren<platformsEnemyChec>().EnemyHere) 
            {
                levelmanager.stepgo();
            }
            else 
            {
                Player.Instance.transform.position = new Vector2(GameObject.Find("platform" + targetposition).transform.position.x, Player.Instance.transform.position.y);
                    Player.Instance.currentposition--;
                    Player.Instance.stepturns++;
                    
                
            }
        }
    }
    public void pressed() //按下时要执行的函数
    {
        GetComponentInParent<stepButton>().havestep = true;
        GetComponentInParent<stepButton>().pressed = false;
        GetComponentInParent<stepButton>().stepname="left";
        GetComponentInParent<stepButton>().choiceclear = false;
        if(GetComponentInParent<stepButton>().stepturns != 4) 
        {
        for (int i = GetComponentInParent<stepButton>().stepturns; i <= 3; i++)
        {
            Player.Instance.stepposition[i]--;
            Player.Instance.stepfacingdir[i] = -1;
        }
        }
        Destroy(gameObject);
    }
}

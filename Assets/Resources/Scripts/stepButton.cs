using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using TMPro;

public class stepButton : MonoBehaviour
{
    public bool pressed;//代表是否被摁下
    public bool pressedcancel;//按钮取消
    public int stepturns;//代表这个脚本附属的物件是第几步
    public bool havestep;//代表这一步骤是否被填充
    public bool choiceclear;//用于判别选择选项后是否清除好了剩余选项
    public string stepname;//保存当前步骤的名字
    public string laststepname;//保存上一步骤的名字，用于判断步骤名字是否发生变换
    public bool bestepped;//表明是否被多步行动占用
    public bool stepenough;
    public List<Transform> transforms;
    public GameObject thisstep;
    public GameObject Grparrow;
    public GameObject Grpweapon;
    public Sprite norbutton;
    public GameObject txt;
    // Start is called before the first frame update
    void Start()
    {
        choiceclear = true;
        transform.Find("normalbutton").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/UI/Button-export");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (bestepped) 
        {
            txt.GetComponent<TMP_Text>().text = "x";
        }
        else 
        {
            txt.GetComponent<TMP_Text>().text = ""+stepturns;
        }
        if (stepturns == Player.Instance.stepturns && !havestep) 
        {
            Debug.Log("skip"+stepturns);
            Player.Instance.stepturns++;//没有填充步骤就跳到下一步
        }
        //跳过
        if (Player.Instance.stepturns == -1)
        {
            for (int i = 0; i < transforms.Count && i < Player.Instance.actions.Count; i++)
            {
                Transform transformnow;//存储当前的变换 
                transformnow = transform.Find(Player.Instance.actions[i] + "(Clone)");
                if (transformnow != null)
                    Destroy(transformnow.gameObject);
            }
            stepname = null;
            choiceclear = true;
            havestep = false;
            bestepped = false;
        }
        //新回合调整
        if (!choiceclear) 
        {
                for(int i = 0; i < transforms.Count && i < Player.Instance.actions.Count; i++) 
                {
                    if (Player.Instance.actions[i] != stepname) 
                    {
                    Transform transformnow;//存储当前的变换 
                    transformnow = transform.Find(Player.Instance.actions[i]+"(Clone)");
                    if (transformnow == null) 
                    {
                        ;
                    }
                    else
                    Destroy(transformnow.gameObject);
                    }
                }
            choiceclear = true;   
        }
        //选定一个选项清理剩余的选项
        if (laststepname != stepname) 
        {
            if (Player.Instance.Objectused.Contains(laststepname)) 
            {
                Player.Instance.Objectused.Remove(laststepname);
            }
            if (laststepname == "left") 
            {
                for (int i = stepturns - 1; i <= 3; i++)
                {
                    Player.Instance.stepposition[i]++;
                }
                for (int i = stepturns - 1; i <= 3; i++)
                {
                    if (GameObject.Find("step" + (i+1)).GetComponent<stepButton>().stepname != "left")
                        Player.Instance.stepfacingdir[i] = 1;
                    else
                        break;
                }
            }
            if (laststepname == "right") 
            {
                for (int i = stepturns - 1; i <= 3; i++)
                {
                    Player.Instance.stepposition[i]--;
                }
                for (int i = stepturns - 1; i <= 3; i++)
                {
                    if (GameObject.Find("step" + (i+1)).GetComponent<stepButton>().stepname != "right")
                        Player.Instance.stepfacingdir[i] = -1;
                    else
                        break;
                }
            }
            if (laststepname == "spring") 
            {
                for (int i = stepturns-1; i <= 3; i++)
                {
                    Player.Instance.stepposition[i]-=2*Player.Instance.stepfacingdir[stepturns];
                }
            }
            if(laststepname == "spring") 
            {
                for (int i = stepturns-1; i <= 3; i++)
                {
                    Player.Instance.stepposition[i] -= 2 * Player.Instance.stepfacingdir[stepturns];
                }
            }
            if (stepname != null) 
            {
                thisstep=transform.Find(stepname+"(Clone)").gameObject;
                GetComponentInChildren<iconbase>(true).gameObject.SetActive(true);
                GetComponentInChildren<iconbase>(true).GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/" + stepname + "-export");
            }
            else 
            {
                thisstep=null;
                GetComponentInChildren<iconbase>(true).gameObject.SetActive(false);
            }
            if(laststepname!="left"&&laststepname!="right") //辨别上一步是否是左右移动（因为左右没有weaponbase脚本附着，会报错）
            {
            if(Resources.Load("prefab/" + laststepname) != null) 
            {
                if (Resources.Load("prefab/" + laststepname).GetComponent<WeaponBase>().step > 1) 
                {
                    for (int i = 1; i < Resources.Load("prefab/" + laststepname).GetComponent<WeaponBase>().step; i++)
                    {
                        GameObject.Find("step" + (stepturns + i)).GetComponent<stepButton>().bestepped = false;
                    }
                }
            }
            }
            if (Player.Instance.Objectused.Contains(laststepname)) 
            {
                Player.Instance.Objectused.Remove(laststepname);
            }
                laststepname = stepname;
        }
        //改变步骤后，如果上一步是多步行动，解除对之后步骤的掌控
        /*if (stepname != null) 
        {
            Debug.Log(stepname);
            if (transform.Find(stepname+"(Clone)").gameObject.GetComponent<WeaponBase>().step > 1) 
            {
                for(int i=1;i< transform.Find(stepname+"(Clone)").gameObject.GetComponent<WeaponBase>().step; i++) 
                {
                    if(GameObject.Find("step"+(stepturns+i))==null|| GameObject.Find("step" + (stepturns + i)).GetComponent<stepButton>().havestep) 
                    {
                        havestep = false;
                        stepname = null;
                        stepenough = false;
                        Debug.Log("not enough step");
                        break;
                    }
                }
            }
        }
        //确定步骤是否足够
        if(transform.Find(stepname + "(Clone)")!=null) 
        {
        if (stepenough&& transform.Find(stepname+"(Clone)").gameObject.GetComponent<WeaponBase>().step > 1) 
        {
            for (int i = 1; i < transform.Find(stepname+"(Clone)").gameObject.GetComponent<WeaponBase>().step; i++)
            {
                GameObject.Find("step" + (stepturns + i)).GetComponent<stepButton>().havestep = true;
                GameObject.Find("step" + (stepturns + i)).GetComponent<stepButton>().bestepped = true;
            }
            stepenough=false;
        }
        }*/
    }
    public void buttonpressed()
    {
        if (!bestepped&&Player.Instance.stepturns==0) 
        {
            pressed = !pressed;
            if (pressed) 
            {
                if (havestep) 
                {
                    Destroy(thisstep);
                }
                transform.Find("normalbutton").GetComponent<Animator>().SetBool("IsSelected", true);
                Grparrow.SetActive(true);
                Grpweapon.SetActive(true);
                for(int i=0;i<transforms.Count&&i<Player.Instance.actions.Count;i++)
                Instantiate(Resources.Load<GameObject>("prefab/" + Player.Instance.actions[i]), transforms[i].position, transforms[i].rotation, this.transform);
            }
            if (!pressed) 
            {
                transform.Find("normalbutton").GetComponent<Animator>().SetBool("IsSelected", false);
                for (int i=0;i<transforms.Count&&i < Player.Instance.actions.Count; i++)
                Destroy(transform.Find(Player.Instance.actions[i]+"(Clone)").gameObject);
                havestep = false;
                stepname = null;
                Grparrow.SetActive(false);
                Grpweapon.SetActive(false);
            }
        }
    }

   
}

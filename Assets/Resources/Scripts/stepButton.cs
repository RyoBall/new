using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class stepButton : MonoBehaviour
{
    public bool pressed;//代表是否被摁下
    public int stepturns;//代表这个脚本附属的物件是第几步
    public bool havestep;//代表这一步骤是否被填充
    public bool choiceclear;//用于判别选择选项后是否清除好了剩余选项
    public string stepname;//保存当前步骤的名字
    public string laststepname;//保存上一步骤的名字，用于判断步骤名字是否发生变换
    public bool bestepped;//表明是否被多步行动占用
    public bool stepenough;
    public List<Transform> transforms;
    // Start is called before the first frame update
    void Start()
    {
        choiceclear = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (bestepped) 
        {
            transform.Find("normalbutton").gameObject.GetComponent<Image>().color = Color.red;
        }
        else 
        {
            transform.Find("normalbutton").gameObject.GetComponent<Image>().color = Color.white;
        }
        if (havestep)
        {
            Debug.Log("havestep");
            transform.Find("normalbutton").gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/" + stepname + "-export");
        }
        else 
        {
            transform.Find("normalbutton").gameObject.GetComponent<Image>().sprite = null;
        }
        if (stepturns == Player.Instance.stepturns && !havestep) 
        {
            Debug.Log("skip");
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
            laststepname = null;
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
                    transformnow=transform.Find(Player.Instance.actions[i]+"(Clone)");
                    if (transformnow == null) 
                    {
                        Debug.Log("error");
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
        if (!bestepped) 
        {
            pressed = !pressed;
            if (pressed) 
            {
                if (havestep) 
                {
                    for (int i = 0; i < transforms.Count && i < Player.Instance.actions.Count; i++)
                    {
                        Transform transformnow;//存储当前的变换 
                        transformnow = transform.Find(Player.Instance.actions[i] + "(Clone)");
                        if (transformnow != null) 
                        {
                            /*if (transformnow.gameObject.GetComponent<WeaponBase>().step > 1) 
                            {
                                for (int j = 1; j < transformnow.gameObject.GetComponent<WeaponBase>().step; j++) 
                                {
                                    GameObject.Find("step" + j).GetComponent<stepButton>().bestepped = false;
                                }
                            };*/
                            Destroy(transformnow.gameObject);
                        }
                    }
                }
                for(int i=0;i<transforms.Count&&i<Player.Instance.actions.Count;i++)
                Instantiate(Resources.Load<GameObject>("prefab/" + Player.Instance.actions[i]), transforms[i].position, transforms[i].rotation,this.transform);
            }
            if (!pressed) 
            {
                for(int i=0;i<transforms.Count&&i < Player.Instance.actions.Count; i++)
                Destroy(transform.Find(Player.Instance.actions[i]+"(Clone)").gameObject);
                havestep = false;
                stepname = null;
            }
        }
    }

   
}

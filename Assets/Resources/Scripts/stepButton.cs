using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class stepButton : MonoBehaviour
{
    public bool pressed;//�����Ƿ�����
    public int stepturns;//��������ű�����������ǵڼ���
    public bool havestep;//������һ�����Ƿ����
    public bool choiceclear;//�����б�ѡ��ѡ����Ƿ��������ʣ��ѡ��
    public string stepname;//���浱ǰ���������
    public string laststepname;//������һ��������֣������жϲ��������Ƿ����任
    public bool bestepped;//�����Ƿ񱻶ಽ�ж�ռ��
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
            Player.Instance.stepturns++;//û����䲽���������һ��
            
        }
        //����
        if (Player.Instance.stepturns == -1)
        {
            for (int i = 0; i < transforms.Count && i < Player.Instance.actions.Count; i++)
            {
                Transform transformnow;//�洢��ǰ�ı任 
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
        //�»غϵ���
        if (!choiceclear) 
        {
            for(int i = 0; i < transforms.Count && i < Player.Instance.actions.Count; i++) 
            {
                if (Player.Instance.actions[i] != stepname) 
                {
                    
                    Transform transformnow;//�洢��ǰ�ı任 
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
        //ѡ��һ��ѡ������ʣ���ѡ��
        if (laststepname != stepname) 
        {
            if(laststepname!="left"&&laststepname!="right") //�����һ���Ƿ��������ƶ�����Ϊ����û��weaponbase�ű����ţ��ᱨ��
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
        //�ı䲽��������һ���Ƕಽ�ж��������֮������ƿ�
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
        //ȷ�������Ƿ��㹻
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
                        Transform transformnow;//�洢��ǰ�ı任 
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

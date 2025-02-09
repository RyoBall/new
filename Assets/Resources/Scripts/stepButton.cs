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
    public bool pressed;//�����Ƿ�����
    public bool pressedcancel;//��ťȡ��
    public int stepturns;//��������ű�����������ǵڼ���
    public bool havestep;//������һ�����Ƿ����
    public bool choiceclear;//�����б�ѡ��ѡ����Ƿ��������ʣ��ѡ��
    public string stepname;//���浱ǰ���������
    public string laststepname;//������һ��������֣������жϲ��������Ƿ����任
    public bool bestepped;//�����Ƿ񱻶ಽ�ж�ռ��
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
        //ѡ��һ��ѡ������ʣ���ѡ��
        if (laststepname != stepname) 
        {
            if (Player.Instance.Objectbackpack.Contains(laststepname)) 
            {
                Player.Instance.Objectbackpack.Remove(laststepname);
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
        if (!bestepped&&Player.Instance.stepturns==0) 
        {
            pressed = !pressed;
            if (pressed) 
            {
                if (havestep) 
                {
                    Destroy(thisstep);
                }
                transform.Find("normalbutton").GetComponent<Animator>().SetBool("isSelected", true);
                Grparrow.SetActive(true);
                Grpweapon.SetActive(true);
                for(int i=0;i<transforms.Count&&i<Player.Instance.actions.Count;i++)
                Instantiate(Resources.Load<GameObject>("prefab/" + Player.Instance.actions[i]), transforms[i].position, transforms[i].rotation, this.transform);
            }
            if (!pressed) 
            {
                transform.Find("normalbutton").GetComponent<Animator>().SetBool("isSelected", false);
                Grparrow.SetActive(false);
                Grpweapon.SetActive(false);
                for (int i=0;i<transforms.Count&&i < Player.Instance.actions.Count; i++)
                Destroy(transform.Find(Player.Instance.actions[i]+"(Clone)").gameObject);
                havestep = false;
                stepname = null;
            }
        }
    }

   
}

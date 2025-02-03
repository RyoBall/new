using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class getObjectController : MonoBehaviour
{
    public List<Transform> transforms;
    public List<Transform> choosetransforms;
    public List<int> randnum;
    public bool buttonClear;//选择界面的按钮是否被删除
    public bool choiceGenerate;
    public static bool dicechoiceGenerate;
    public int winGenerate;
    public bool choosegenerate;
    public bool nogenerate;
    // Start is called before the first frame update
    void Start()
    {
        dicechoiceGenerate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("levelmanager").GetComponent<levelmanager>().choosecard&&!choosegenerate) 
        {
            for(int i = 0; i < choosetransforms.Count && i < Player.Weaponbag.Count; i++) 
            {
                Instantiate(Resources.Load("prefab/choose/choose" + Player.Weaponbag[i]), choosetransforms[i].position, choosetransforms[i].rotation, this.transform);
            }
                Instantiate(Resources.Load("prefab/choose/chooseend"), transform.Find("chooseend").position, transform.Find("chooseend").rotation, this.transform);
            choosegenerate = true;
        }
        else if(!GameObject.Find("levelmanager").GetComponent<levelmanager>().choosecard)
        {
        if (!GameObject.Find("levelmanager").GetComponent<levelmanager>().win&& !GameObject.Find("levelmanager").GetComponent<levelmanager>().lose) 
        { 
        if (GetComponent<heimucontroller>().loaded && !dicechoiceGenerate) 
        {
            for(int i = 1; i <= 2; i++) 
            {
               Instantiate(Resources.Load<GameObject>("prefab/dicing/action"+i ), transforms[i].position, transforms[i].rotation, this.transform);
            }
            dicechoiceGenerate = true;
        }
        if (GetComponent<heimucontroller>().loaded&&!choiceGenerate) 
        {
                    nogenerate = true;
                if (Player.Instance.actions.Count == 3) 
                {
                for (int i = 0; i < transforms.Count&&i<Player.Instance.backpack.Count-1; i++) 
                {
                int m;
                while (true) 
                {
                    m=Random.Range(0, Player.Instance.backpack.Count);
                    if (!randnum.Contains(m) && !Player.Instance.actions.Contains(Player.Instance.backpack[m])) 
                    {
                        break;
                    }
                }
                randnum.Add(m);
                Instantiate(Resources.Load<GameObject>("prefab/getting" + Player.Instance.backpack[m]), transforms[i].position, transforms[i].rotation,this.transform);
                }
                }
                else if (Player.Instance.actions.Count==5) 
                {
                    Player.Instance.stepturns=0;           
                }
                else 
                {
                    for (int i = 0; i < transforms.Count && i < Player.Instance.backpack.Count; i++)
                    {
                        int m;
                        while (true)
                        {
                            m = Random.Range(0, Player.Instance.backpack.Count);
                            if (!randnum.Contains(m) && !Player.Instance.actions.Contains(Player.Instance.backpack[m]))
                            {
                                break;
                            }
                        }
                        randnum.Add(m);
                        Instantiate(Resources.Load<GameObject>("prefab/getting" + Player.Instance.backpack[m]), transforms[i].position, transforms[i].rotation, this.transform);
                    }
                }
                for(int i = 0; i < Player.Instance.allobject.Count; i++) 
                    {
                        if (transform.Find("getting" + Player.Instance.allobject[i] + "(Clone)") != null) 
                        {
                            nogenerate = false;
                        }
                    }
                    if (nogenerate) 
                    {
                        Player.Instance.stepturns = 0;
                    }
            randnum.Clear();
            Debug.Log("Generate");
            buttonClear = false;
            choiceGenerate = true;
        }
        if (Player.Instance.stepturns != -1&&buttonClear==false) 
        {
            for(int i = 0; i < Player.Wholebackpack.Count;i++) 
            {
                if (transform.Find("getting"+Player.Wholebackpack[i]+"(Clone)") != null) 
                {
                    Destroy(transform.Find("getting"+Player.Wholebackpack[i]+"(Clone)").gameObject);
                }
            }
            buttonClear = true;
        }
        }
        else if(GameObject.Find("levelmanager").GetComponent<levelmanager>().win)
        {
            if (winGenerate==0&&GetComponentInParent<heimucontroller>().loaded) 
            {
                for (int i = 0; i < transforms.Count && i <Player.Instance.Weaponobject.Count-Player.Weaponbag.Count+3; i++)
                {
                    int m=-1;
                    for(int j=0;j<50;j++)
                    {
                        m = Random.Range(0, Player.Instance.Weaponobject.Count);
                        if (!randnum.Contains(m) && !Player.Weaponbag.Contains(Player.Instance.Weaponobject[m]))
                        {
                            break;
                        }
                    }
                    if(m!=-1)
                    randnum.Add(m);
                    Instantiate(Resources.Load<GameObject>("prefab/have/have" + Player.Instance.Weaponobject[m]), transforms[i].position, transforms[i].rotation, this.transform);
                } 
                winGenerate = 1;
                randnum.Clear();
            }   
            if (winGenerate==2&&GetComponentInParent<heimucontroller>().loaded) 
            {
                for (int i = 0; i < transforms.Count && i <Player.Instance.otherobject.Count-Player.Objectbag.Count; i++)
                {
                    int m;
                    while (true)
                    {
                        m = Random.Range(0, Player.Instance.otherobject.Count);
                        if (!randnum.Contains(m) && !Player.Objectbag.Contains(Player.Instance.otherobject[m]))
                        {
                            break;
                        }
                    }
                    randnum.Add(m);
                    Instantiate(Resources.Load<GameObject>("prefab/have/have" + Player.Instance.otherobject[m]), transforms[i].position, transforms[i].rotation, this.transform);
                }
                randnum.Clear();
                winGenerate = 3;
            }
        }
        else if (GameObject.Find("levelmanager").GetComponent<levelmanager>().lose) 
        {
            Debug.Log("try again");
            SceneManager.LoadScene("level" + GameObject.Find("levelmanager").GetComponent<levelmanager>().currentlevel);
        }
        }
    }
}

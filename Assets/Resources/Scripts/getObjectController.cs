using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class getObjectController : MonoBehaviour
{
    public List<Transform> transforms;
    public List<RectTransform> choosetransforms;
    public List<int> randnum;
    public bool buttonClear;//
    public bool choiceGenerate;
    public static bool dicechoiceGenerate;
    public int winGenerate;
    public bool choosegenerate;
    public bool nogenerate;

    [SerializeField] heimucontroller heimucontroller;
    [SerializeField] GameObject uiSelectPanel;
    [SerializeField] GameObject uiChooseCard;
    // Start is called before the first frame update
    void Start()
    {
        dicechoiceGenerate = true;
        uiChooseCard.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("levelmanager").GetComponent<levelmanager>().choosecard&&!choosegenerate) 
        {
            for(int i = 0; i < choosetransforms.Count && i < Player.Weaponbag.Count; i++) 
            {
                Instantiate(Resources.Load("prefab/choose/choose" + Player.Weaponbag[i]), choosetransforms[i].position, choosetransforms[i].rotation, choosetransforms[i]);
                Debug.Log($"{Player.Weaponbag[i]}生成的位置在{choosetransforms[i].position}");
            }
            choosegenerate = true;
            uiChooseCard.SetActive(false);
            uiSelectPanel.SetActive(true);
        }
        else if(!GameObject.Find("levelmanager").GetComponent<levelmanager>().choosecard)
        {
            uiSelectPanel.SetActive(false);
            if (!GameObject.Find("levelmanager").GetComponent<levelmanager>().win&& !GameObject.Find("levelmanager").GetComponent<levelmanager>().lose) 
            { 

        if (heimucontroller.loaded && !dicechoiceGenerate) 
        {
            for(int i = 1; i <= 2; i++) 
            {
               Instantiate(Resources.Load<GameObject>("prefab/dicing/action"+i ), transforms[i].position, transforms[i].rotation, transforms[i]);
            }
            dicechoiceGenerate = true;
        }
        if (heimucontroller.loaded&&!choiceGenerate) 
        {
                uiChooseCard.SetActive(true);
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
                Instantiate(Resources.Load<GameObject>("prefab/getting" + Player.Instance.backpack[m]), transforms[i].position, transforms[i].rotation, transforms[i]);
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
                        Instantiate(Resources.Load<GameObject>("prefab/getting" + Player.Instance.backpack[m]), transforms[i].position, transforms[i].rotation, transforms[i]);
                    }
                }
                    for(int j = 0; j < 3; j++)
                    {
                        for(int i = 0; i < Player.Instance.allobject.Count; i++) 
                        {
                            if (transforms[j].Find("getting" + Player.Instance.allobject[i] + "(Clone)") != null) 
                            {
                                nogenerate = false;
                            }
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

                if (Player.Instance.stepturns != -1 && buttonClear == false)
                {
                    for (int j = 0; j < 3; j++) 
                    {
                        for(int i = 0; i < Player.Wholebackpack.Count;i++) 
                        {
                            if (transforms[j].Find("getting"+Player.Wholebackpack[i]+"(Clone)") != null) 
                            {
                                Destroy(transforms[j].Find("getting"+Player.Wholebackpack[i]+"(Clone)").gameObject);
                                Debug.Log("destroy");
                            }
                        }
                    }
                        buttonClear = true;
                        uiChooseCard.SetActive(false);
                }
        }
        else if(GameObject.Find("levelmanager").GetComponent<levelmanager>().win)
        {
            if (winGenerate==0&& heimucontroller.loaded) 
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
                    Instantiate(Resources.Load<GameObject>("prefab/have/have" + Player.Instance.Weaponobject[m]), transforms[i].position, transforms[i].rotation, transforms[i]);
                } 
                winGenerate = 1;
                randnum.Clear();
            }   
            if (winGenerate==2&& heimucontroller.loaded) 
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
                    Instantiate(Resources.Load<GameObject>("prefab/have/have" + Player.Instance.otherobject[m]), transforms[i].position, transforms[i].rotation, transforms[i]);
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


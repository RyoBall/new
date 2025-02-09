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
    public bool chooosegenerate;
    public bool nogenerate;
    public static bool dicegenerate;
    public bool dicebuttonClear;
    [SerializeField] heimucontroller heimucontroller;
    [SerializeField] GameObject uiSelectPanel;
    [SerializeField] GameObject uiChooseCard;
    // Start is called before the first frame update
    void Start()
    {
        dicechoiceGenerate = true;
        dicebuttonClear = true;
        uiChooseCard.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("levelmanager").GetComponent<levelmanager>().choosecard&&!chooosegenerate) 
        {
            uiChooseCard.SetActive(false);
            uiSelectPanel.SetActive(true);
            chooosegenerate = true;
            for(int i = 0; i < choosetransforms.Count && i < Player.Weaponbag.Count; i++) 
            {
                Instantiate(Resources.Load("prefab/choose/choose" + Player.Weaponbag[i]), choosetransforms[i].position, choosetransforms[i].rotation, choosetransforms[i]);
                Debug.Log($"{Player.Weaponbag[i]}生成的位置在{choosetransforms[i].position}");
            }
        }
        else if(!GameObject.Find("levelmanager").GetComponent<levelmanager>().choosecard)
        {
            uiSelectPanel.SetActive(false);
            if (!GameObject.Find("levelmanager").GetComponent<levelmanager>().win && !GameObject.Find("levelmanager").GetComponent<levelmanager>().lose)
            {
                if (heimucontroller.loaded && !dicechoiceGenerate)
                {
                    uiChooseCard.SetActive(true);
                    Instantiate(Resources.Load<GameObject>("prefab/dicing/action" + 1), transforms[0].position, transforms[0].rotation, transforms[0]);
                    Instantiate(Resources.Load<GameObject>("prefab/dicing/action" + 2), transforms[2].position, transforms[2].rotation, transforms[2]);
                    dicechoiceGenerate = true;
                }
                if (levelmanager.dicing && !dicegenerate)
                {
                    dicegenerate = true;
                    uiChooseCard.SetActive(true);
                    nogenerate = true;
                    for (int i = 0; i < transforms.Count && i < Player.Instance.Weaponbackpack.Count - 2; i++)
                    {
                        Debug.Log("Generate");
                        int m;
                        while (true)
                        {
                            m = Random.Range(0, Player.Instance.Weaponbackpack.Count);
                            if (!randnum.Contains(m) && !Player.Instance.actions.Contains(Player.Instance.Weaponbackpack[m]))
                            {
                                break;
                            }
                        }
                        randnum.Add(m);
                        Instantiate(Resources.Load<GameObject>("prefab/getting" + Player.Instance.Weaponbackpack[m]), transforms[i].position, transforms[i].rotation, transforms[i]);
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        for (int i = 0; i < Player.Instance.allobject.Count; i++)
                        {
                            if (transforms[j].Find("getting" + Player.Instance.allobject[i] + "(Clone)") != null)
                            {
                                nogenerate = false;
                            }
                        }
                    }
                    if (nogenerate)
                    {
                        Debug.Log("nogenerate");
                        Player.Instance.stepturns = 0;
                    }
                    randnum.Clear();
                    dicebuttonClear = false;
                }
                if (!levelmanager.dicing && dicebuttonClear == false)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        for (int i = 0; i < Player.Wholebackpack.Count; i++)
                        {
                            if (transforms[j].Find("getting" + Player.Wholebackpack[i] + "(Clone)") != null)
                            {
                                Destroy(transforms[j].Find("getting" + Player.Wholebackpack[i] + "(Clone)").gameObject);
                                Debug.Log("destroy");
                            }
                        }
                    }
                    dicebuttonClear = true;
                    uiChooseCard.SetActive(false);
                }
                //以上为骰子用代码
                if ((heimucontroller.loaded && !choiceGenerate))
                {
                    uiChooseCard.SetActive(true);
                    nogenerate = true;
                    /*if (Player.Instance.actions.Count == 3&&Player.Instance.backpackisweapon) 
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
                    }*/
                    if (Player.Instance.actions.Count == 5 || (Player.Instance.Weaponbackpack.Count == 1 && Player.Instance.actions.Count == 4))
                    {
                        Player.Instance.stepturns = 0;
                    }
                    else
                    {
                        for (int i = 0; i < transforms.Count && i < Player.Instance.backpack.Count - Player.Instance.instantiated; i++)
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
                    for (int j = 0; j < 3; j++)
                    {
                        for (int i = 0; i < Player.Instance.allobject.Count; i++)
                        {
                            if (transforms[j].Find("getting" + Player.Instance.allobject[i] + "(Clone)") != null)
                            {
                                nogenerate = false;
                            }
                        }
                    }
                    if (nogenerate)
                    {
                        Debug.Log("nogenerate");
                        Player.Instance.stepturns = 0;
                    }
                    randnum.Clear();
                    Debug.Log("Generate");
                    buttonClear = false;
                    choiceGenerate = true;
                }

                if (Player.Instance.stepturns == 0 && buttonClear == false)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        for (int i = 0; i < Player.Wholebackpack.Count; i++)
                        {
                            if (transforms[j].Find("getting" + Player.Wholebackpack[i] + "(Clone)") != null)
                            {
                                Destroy(transforms[j].Find("getting" + Player.Wholebackpack[i] + "(Clone)").gameObject);
                                Debug.Log("destroy");
                            }
                        }
                    }
                    buttonClear = true;
                    uiChooseCard.SetActive(false);
                }
            }
            else if (GameObject.Find("levelmanager").GetComponent<levelmanager>().win && GameObject.Find("levelmanager").GetComponent <levelmanager>().currentlevel!=8)
        {
            if (winGenerate==0&& heimucontroller.loaded) 
            {
                uiChooseCard.SetActive(true);
                for (int i = 0; i < transforms.Count && i <Player.Instance.Weaponobject.Count-Player.Weaponbag.Count+3; i++)
                {
                    int m=-1;
                    while(true)
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
        
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class levelmanager : MonoBehaviour
{
    public static int nowlevel;
    public List<GameObject> enemys;
    public static bool deathnotechoosing;
    public static bool changerchoosing;
    public static bool dicingchoose;
    public static bool dicing;
    public static int dicingstep;//Ҫ���ĵ������ĸ���
    public  bool win;
    public  bool lose;
    public int currentlevel;
    public static bool notfirstplay;
    public bool choosecard;
    public int maprange;//��ͼ���� 
    public bool notfinished;//�����Ƿ�������
    public static bool stepnext;
    public float loadtime;
    public static bool entityexist;
    public static bool endgame;
    public static bool stepnotenoughtip;
    public GameObject choosetip;
    public GameObject steptip;
    // Start is called before the first frame update
    void Start()
    {

        choosecard = true;
        if (!Player.Weaponbag.Contains("knife")&&!notfirstplay) 
        {
            Player.Wholebackpack.Add("knife");
            Player.Weaponbag.Add("knife");
            Player.Wholebackpack.Add("sniperrifle");
            Player.Weaponbag.Add("sniperrifle");
            Player.Wholebackpack.Add("hook");
            Player.Weaponbag.Add("hook");
            Player.Wholebackpack.Add("spring");
            Player.Objectbag.Add("spring");
            notfirstplay = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stepnotenoughtip)
        {
            stepnotenoughtip = false;
            steptip.SetActive(true);
            steptip.GetComponent<tiptxt>().tiping=true;
        }
        if (changerchoosing || deathnotechoosing)
        {
            choosetip.SetActive(true);
        }
        else 
        {
            choosetip.SetActive(false);
        }
        nowlevel=currentlevel;
        if (stepnext) 
        {
            loadtime += Time.deltaTime;
            if (loadtime > 0.2f) 
            {
                loadtime = 0;
                Player.Instance.stepturns++;
                stepnext = false;   
            }
        }
        if (Player.Instance.stepturns == -1) 
        {
            notfinished = true;
        }
        if (Player.Instance.stepturns >= 5) 
        {
        for(int i = 0; i < enemys.Count; i++) 
        {
            if (enemys[i].GetComponent<enemy>().notfinished == true) 
            {
                goto notfinish;
            }
        }
        notfinished = false;
        }
        notfinish:
        if (Player.Instance.stepturns == 5 && !notfinished&&!entityexist) 
        {
            Player.Instance.stepturns = -1;
            Player.Instance.turn++;
            GameObject.Find("mask").GetComponent<getObjectController>().choiceGenerate = false;
        }
        if (choosecard) 
        {
            ;
        }
        else 
        {
        for(int i = 0; i < enemys.Count; i++) 
        {
            if(enemys[i].GetComponent<enemy>().dead != true) 
            {
                goto nowin;
            }
        }
        win = true;
        goto win;
    nowin:
        if (Player.Instance.health <= 0) 
        {
            lose = true;
        }
    win:
        if (win) 
        {
                if (currentlevel == 8) 
                {
                    SceneManager.LoadScene("endScene");
                }
        };
        }
    }
    public static void stepgo() 
    {
        stepnext = true;
    }
}

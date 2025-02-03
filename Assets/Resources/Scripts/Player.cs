using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int turn;
    public int lastturn;
    public float health;
    public float healthmax;
    public int facingdir;
    public bool turnend;
    public static Player Instance;
    public Rigidbody2D rb;
    public int stepturns;//当前进行到的step数，当数值为一时开始进行第一步的函数,类推直到5时变为-1，为-1时说明进入了下一个回合,调整ui等结束后变为0，进入回合
    public List<string> actions = new List<string>();//玩家拥有的行动的名字列表
    public List<string> backpack = new List<string>();//玩家当前加载的道具列表
    public List<string> Objectbackpack = new List<string>();//玩家背包的道具列表
    public List<string> Weaponbackpack = new List<string>();//玩家背包的武器列表
    public int currentposition;//代表当前所在的格数
    public List<string> Objectused = new List<string>();
    public List<int> stepposition = new List<int>();
    public List<int> stepfacingdir = new List<int>();
    public List<string> allobject = new List<string>();//记录所有的武器道具
    public List <string> Weaponobject = new List<string>();
    public List <string> otherobject = new List<string>();
    public static List<string> Wholebackpack = new List<string>();//玩家总背包列表
    public static List <string> Weaponbag = new List<string>();//记录拥有的武器
    public static List <string> Objectbag = new List<string>();//记录拥有的道具
    public int dashtargetposition;
    public bool dashed;
    // Start is called before the first frame update
    private void Awake()
    {
        turnend= false;
        Instance = this;
        rb=GetComponent<Rigidbody2D>();
        turn = 1;
        lastturn = 1;
    }
    void Start()
    {
        facingdir = 1;   
    }

    // Update is called once per frame
    void Update()
    {
        Objectbackpack = Objectbag;
        if (actions.Count >= 4)
        {
            backpack=Objectbackpack;
        }
        else 
        {
            backpack = Weaponbackpack;
        }
        if (stepturns == -1)//-1步的代码 
        {
            for (int i = 0; i < 4; i++)
            {
                stepposition[i] = currentposition;
            }
            for(int i = 0; i < 4; i++) 
            {
                stepfacingdir[i]=facingdir;
            }
            dashed = true;
            dashtargetposition = 0;
        }
        if (stepturns > 0) //回合开始后的代码，比-1步时间上优先级高
        {
            if (actions.Count >= 5) 
            {
            if (Objectused.Contains(actions[4])) 
                {
                    actions.Remove(actions[4]);
                }
            }
        }
        if (lastturn != turn) //回合转换的代码，在-1步只执行一次,第一回合不执行
        {
            health--;
            lastturn = turn;
            Objectused.Clear();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") 
        {
        if (other.GetComponent<enemy>().currentposition == dashtargetposition&&!dashed) 
        {
            other.GetComponent<enemy>().health-=GameObject.Find("step"+stepturns).GetComponentInChildren<WeaponBase>().attack;
            dashed = true;
        }
        }
    }
}

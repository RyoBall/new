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
    public int stepturns;//��ǰ���е���step��������ֵΪһʱ��ʼ���е�һ���ĺ���,����ֱ��5ʱ��Ϊ-1��Ϊ-1ʱ˵����������һ���غ�,����ui�Ƚ������Ϊ0������غ�
    public List<string> actions = new List<string>();//���ӵ�е��ж��������б�
    public List<string> backpack = new List<string>();//��ҵ�ǰ���صĵ����б�
    public List<string> Objectbackpack = new List<string>();//��ұ����ĵ����б�
    public List<string> Weaponbackpack = new List<string>();//��ұ����������б�
    public int currentposition;//�����ǰ���ڵĸ���
    public List<string> Objectused = new List<string>();
    public List<int> stepposition = new List<int>();
    public List<int> stepfacingdir = new List<int>();
    public List<string> allobject = new List<string>();//��¼���е���������
    public List <string> Weaponobject = new List<string>();
    public List <string> otherobject = new List<string>();
    public static List<string> Wholebackpack = new List<string>();//����ܱ����б�
    public static List <string> Weaponbag = new List<string>();//��¼ӵ�е�����
    public static List <string> Objectbag = new List<string>();//��¼ӵ�еĵ���
    public int dashtargetposition;
    public bool dashed;
    public int targetposition;
    public bool notspringed;
    public int turnvector;
    public int laststepturn;
    public List<GameObject> steps = new List<GameObject>();
    public Transform shootposition; 
    [Header("animevent")]
    public Animator anim;
    public bool knife;
    public bool bow;
    public bool gun;
    public bool sword;
    public bool hugesword;
    public bool dash;
    public bool baton;
    public bool burst;
    public bool sniper;
    public bool hook;
    public bool move;
    public bool hookattached;
    public bool hooknotattached;
    public bool hookfinish;
    public bool dashend;
    public bool attackedthisstep;
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
        anim.SetBool("bow", bow);
        anim.SetBool("knife", knife);
        anim.SetBool("gun", gun);
        anim.SetBool("bow", bow);
        anim.SetBool("sword", sword);
        anim.SetBool("hugesword", hugesword);
        anim.SetBool("dash", dash);
        anim.SetBool("dashend", dashend);
        anim.SetBool("baton", baton);
        anim.SetBool("burst", burst);
        anim.SetBool("sniper", sniper);
        anim.SetBool("hook", hook);
        anim.SetBool("move", move);
        anim.SetBool("hookattached", hookattached);
        anim.SetBool("hooknotattached", hooknotattached);
        anim.SetBool("hookfinish", hookfinish);
        if (laststepturn != stepturns) 
        {
            attackedthisstep = false;
            laststepturn = stepturns;
        }
        if (facingdir == 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else 
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        Objectbackpack = Objectbag;
        if (actions.Count >= 4)
        {
            backpack=Objectbackpack;
        }
        else 
        {
            backpack = Weaponbackpack;
        }
        if (stepturns == -1)//-1���Ĵ��� 
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
        if (stepturns > 0) //�غϿ�ʼ��Ĵ��룬��-1��ʱ�������ȼ���
        {
            if (actions.Count >= 5) 
            {
            if (Objectused.Contains(actions[4])) 
                {
                    actions.Remove(actions[4]);
                }
            }
        }
        if (lastturn != turn) //�غ�ת���Ĵ��룬��-1��ִֻ��һ��,��һ�غϲ�ִ��
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
    public void spring() 
    {
        GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("effect/change");
        GetComponent<AudioSource>().Play();
        facingdir = turnvector;
        if (GameObject.Find("platform" + targetposition) != null && !GameObject.Find("platform" +targetposition).GetComponentInChildren<platformsEnemyChec>().EnemyHere)
        {   
            transform.position=new Vector2(transform.position.x+(targetposition-currentposition)*1.5f,transform.position.y);
            currentposition=targetposition;
        }
    }
    public void attack() 
    {
        if (!attackedthisstep) 
        {
        Debug.Log("attacked");
        GameObject.Find("step" + stepturns).GetComponent<stepButton>().thisstep.GetComponent<WeaponBase>().attacked=false;
        GameObject.Find("step" + stepturns).GetComponent<stepButton>().thisstep.GetComponent<WeaponBase>().shooted=false;
        attackedthisstep = true;
        }
    }
    public void finish() 
    {
        bow=false;
        knife=false;
        gun=false;
        sniper=false;
        baton=false;
        burst=false;
        hugesword=false;
        sword=false;
        dash = false;
        hook = false;
        hookattached = false;
        hooknotattached = false;
        hookfinish = false;
        dashend = false;
    }
    public void springfinish() 
    {
        move=false;
        stepturns++;
    }
}

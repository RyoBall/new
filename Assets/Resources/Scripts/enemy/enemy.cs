using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using static UnityEditor.Experimental.GraphView.GraphView;
#endif

public class enemy : MonoBehaviour
{
    public int facingdir;
    public float healthmax;
    public float health;
    public float lasthealth;
    public bool attacked;
    public bool notfinished;
    public int currentposition;
    public bool ismoving;
    public int step;
    public int dir;
    public bool dead;
    public bool electricted;
    public int laststepturns;
    public bool havedefense;
    public Animator animator;
    // Start is called before the first frame update
    public virtual void OnMouseDown()
    {
        if (levelmanager.deathnotechoosing) 
        {
            health = 0;
            levelmanager.deathnotechoosing = false;
            Player.Instance.stepturns++;
            
        }
        if (levelmanager.changerchoosing) 
        {
            Vector3 trans=transform.position;
            int position = currentposition;//¥Ê¥¢µ±«∞Œª÷√
            currentposition=Player.Instance.currentposition;
            transform.position = Player.Instance.transform.position;
            Player.Instance.currentposition = position;
            Player.Instance.transform.position = trans;
            Player.Instance.stepturns++;
            
        }
    }
    public void Start()
    { 
        animator = GetComponent<Animator>();
        health = 4;
        healthmax = 4;
       lasthealth = health;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (currentposition > Player.Instance.currentposition) 
        {
            facingdir = -1;
        }
        else 
        {
            facingdir = 1;
        }
        if (facingdir == 1) 
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (facingdir == -1) 
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (health <= 0&&!havedefense) 
        {
            dead = true;
        }
        if (lasthealth > health&&!dead) 
        {
            attacked = true;
            lasthealth=health;
        }
        if (health < 0) 
        {
            health = 0;
        }
        GetComponentInChildren<Slider>().value = health/healthmax;
        if (Player.Instance.stepturns == -1) 
        {
            electricted = false;
            laststepturns = 0;
        }
        Move(step, dir);
        if (electricted) 
        {
            if (laststepturns != Player.Instance.stepturns) 
            {
                laststepturns= Player.Instance.stepturns;
                health -= 2;
            }   
        }
        animator.SetBool("attacked", attacked);
        animator.SetBool("dead", dead);
    }
    public virtual void Move(int step,int dir)
    {
        if (ismoving) 
        {
            int targetposition = currentposition + step*dir;
            if (GameObject.Find("platform" + targetposition) == null || GameObject.Find("platform" + targetposition).GetComponentInChildren<platformsEnemyChec>().PlayerHere)
            {
                Debug.Log(targetposition);
                ismoving = false;
                Player.Instance.stepturns++;
                if (Player.Instance.stepturns == 5)
                Player.Instance.stepturns = -1;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(30*dir, 0);
                if ((transform.position.x >= GameObject.Find("platform" + targetposition).transform.position.x&&dir>0)|| (transform.position.x <= GameObject.Find("platform" + targetposition).transform.position.x && dir < 0))
                {
                    Debug.Log("movfinish");
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    currentposition+=step*dir;
                    ismoving = false;
                    dir = 0;
                    step = 0;
                    Player.Instance.stepturns++;
                   
                }
            }
        }
    }
    public virtual void attackedfinished() 
    {
        attacked = false;
    }
    public virtual void deaded() 
    {
        notfinished = false;    
        gameObject.SetActive(false);
    }
    public virtual void startdie() 
    {
        notfinished = true;
    }
}

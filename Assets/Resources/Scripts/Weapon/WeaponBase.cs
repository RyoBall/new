using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public bool used;
    public bool shooted;
    public bool choosing;
    public int step;
    public int range;
    public float time;
    public int attack;
    public int attackedenemy;
    public bool attacked;
    public bool mingzhong;
    public bool start;
    public bool finish;
    public bool hook;
    public GameObject Entity;
    
    public virtual void function(bool players) //到相应步骤要执行的函数
    {
        if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns)
        {
            if (!attacked) 
            {
                GetComponent<AudioSource>().Play();
                for (int i = 1; i <= range; i++)
                {
                    if(GameObject.Find("platform" + (Player.Instance.currentposition + i * Player.Instance.facingdir)) == null) 
                    {
                        break;
                    }//攻击越界
                    if (GameObject.Find("platform" + (Player.Instance.currentposition + i * Player.Instance.facingdir)).GetComponentInChildren<platformsEnemyChec>().EnemyHere)
                    {
                        GameObject.Find("platform" + (Player.Instance.currentposition + i * Player.Instance.facingdir)).GetComponentInChildren<platformsEnemyChec>().Damage = attack;
                        GameObject.Find("platform" + (Player.Instance.currentposition + i * Player.Instance.facingdir)).GetComponentInChildren<platformsEnemyChec>().PlayerAttackHere = true;
                        mingzhong = true;
                        break;
                    }
                }
                    attacked = true;
                if (!mingzhong) 
                {
                    levelmanager.stepgo();
                }
            }
                if (attackedenemy > 0) 
                {
                    levelmanager.stepgo(); 
                }
        }
    }
    public virtual void shootfunction(GameObject Entity,bool players) 
    {
        if (Player.Instance.stepturns == GetComponentInParent<stepButton>().stepturns&&!shooted)
        {
        if (!start) 
        {
            players = true;
            start = true;
        }
            GameObject Instan;
            GetComponent<AudioSource>().Play();
            Instan=Instantiate(Entity, Player.Instance.shootposition.position, Player.Instance.shootposition.rotation);
            Instan.GetComponent<EntityBase>().damage = attack;
            if(!hook)
            levelmanager.stepgo();
            shooted = true;
        }
    }
    public virtual void pressed(string name) //按下时要执行的函数
    {
        GetComponentInParent<stepButton>().havestep = true;
        GetComponentInParent<stepButton>().pressed = false;
        GetComponentInParent<stepButton>().stepname = name;
        GetComponentInParent<stepButton>().stepenough = true;
        GetComponentInParent<stepButton>().choiceclear = false;
        GetComponentInParent<stepButton>().Grparrow.SetActive(false);
        GetComponentInParent<stepButton>().Grpweapon.SetActive(false);
        if (GetComponentInParent<stepButton>().stepname != null)
        {
            if (step > 1)
            {
                for (int i = 1; i < step; i++)
                {
                    if (GameObject.Find("step" + (GetComponentInParent<stepButton>().stepturns + i)) == null || GameObject.Find("step" + (GetComponentInParent<stepButton>().stepturns + i)).GetComponent<stepButton>().havestep|| GameObject.Find("step" + (GetComponentInParent<stepButton>().stepturns + i)).GetComponent<stepButton>().bestepped)
                    {
                        GetComponentInParent<stepButton>().havestep = false;
                        GetComponentInParent<stepButton>().stepname = null;
                        GetComponentInParent<stepButton>().stepenough = false;
                        GetComponentInParent<stepButton>().choiceclear=false;
                        Debug.Log("not enough step");
                        break;
                    }
                }
            }
        }
        //确定步骤是否足够
        
            if (GetComponentInParent<stepButton>().stepenough && step > 1)
            {
                for (int i = 1; i < step; i++)
                {
                    GameObject.Find("step" + (GetComponentInParent<stepButton>().stepturns + i)).GetComponent<stepButton>().bestepped = true;
                }
                GetComponentInParent<stepButton>().stepenough = false;
            }
        Destroy(gameObject);
    }
}

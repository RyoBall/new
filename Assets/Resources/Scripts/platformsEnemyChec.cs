using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformsEnemyChec : MonoBehaviour
{
    public bool EnemyHere;
    public bool PlayerHere;
    public bool haselectric;
    public bool swordattackhere;
    public bool PlayerAttackHere;//表明是否在此处造成伤害
    public int Damage;//作为造成伤害的接口，从step中接收本次的伤害值（造成伤害的原理是检测到这块平台上有敌人，然后造成伤害）
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy") 
        {
            EnemyHere = true;
            if (PlayerAttackHere) 
            {
                other.gameObject.GetComponent<enemy>().health -= Damage;
                Damage = 0;
                if (haselectric) 
                {
                    other.GetComponent<enemy>().electricted=true;
                    other.GetComponent<enemy>().laststepturns=Player.Instance.stepturns;
                }
                
                haselectric = false;
                PlayerAttackHere = false;
                GameObject.Find("step" + Player.Instance.stepturns).transform.Find(GameObject.Find("step" + Player.Instance.stepturns).GetComponent<stepButton>().stepname+"(Clone)").gameObject.GetComponent<WeaponBase>().attackedenemy++;
            }
            if (other.GetComponent<enemy>().dead) 
            {
                EnemyHere= false;
            }
        }
        if (other.tag == "Player") 
        {
            PlayerHere=true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") 
        {
            EnemyHere=false;
        }
        if (collision.tag == "Player") 
        {
            PlayerHere=false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformsEnemyChec : MonoBehaviour
{
    public bool EnemyHere;
    public bool PlayerHere;
    public bool haselectric;
    public bool swordattackhere;
    public bool PlayerAttackHere;//�����Ƿ��ڴ˴�����˺�
    public int Damage;//��Ϊ����˺��Ľӿڣ���step�н��ձ��ε��˺�ֵ������˺���ԭ���Ǽ�⵽���ƽ̨���е��ˣ�Ȼ������˺���
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookEntity : EntityBase 
{
    
    public override void function()
    {
        base.function();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
        for (; true;)
        {
            int i = Random.Range(0, GameObject.Find("levelmanager").GetComponent<levelmanager>().enemys.Count);
            if (GameObject.Find("levelmanager").GetComponent<levelmanager>().enemys[i].GetComponent<enemy>().currentposition == collision.GetComponent<enemy>().currentposition && !GameObject.Find("levelmanager").GetComponent<levelmanager>().enemys[i].GetComponent<enemy>().dead)
            {
                collision.gameObject.GetComponent<enemy>().health -= damage;
                collision.gameObject.GetComponent<enemy>().ismoving =true;
                collision.gameObject.GetComponent<enemy>().dir=Player.Instance.facingdir*(-1);
                collision.gameObject.GetComponent<enemy>().step=1;
                break;
            }
        }
            Destroy(gameObject);
        }
        /*if (transform.position.x >= GameObject.Find("platform" + targetposition).transform.position.x && Player.Instance.facingdir == 1 || transform.position.x <= GameObject.Find("platform" + targetposition).transform.position.x && Player.Instance.facingdir == -1)
        {
            Player.Instance.stepturns++;
            if (Player.Instance.stepturns == 5)
            {
                Player.Instance.stepturns = -1;
                Player.Instance.turn++;
               GameObject.Find("mask").GetComponent<getObjectController>().choiceGenerate = false;
            }
            Destroy(gameObject);
        }*/
    }

    public override void Start()
    {
        range = 4;
        base.Start();
    }

    // Start is called before the first frame update


    // Update is called once per frame
    new void Update()
    {
        function();
    }
}

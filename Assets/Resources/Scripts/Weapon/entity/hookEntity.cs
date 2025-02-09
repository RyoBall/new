using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookEntity : EntityBase 
{
    
    public override void function()
    {
        rb.velocity = new Vector2(20 * Player.Instance.facingdir, 0);
        if ((transform.position.x >= GameObject.Find("platform" + targetposition).transform.position.x && Player.Instance.facingdir == 1) || (transform.position.x <= GameObject.Find("platform" + targetposition).transform.position.x && Player.Instance.facingdir == -1))
        {
            Player.Instance.hooknotattached = true;
            Player.Instance.stepturns++;
            Destroy(gameObject);
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (!collision.GetComponent<enemy>().dead)
            {
                collision.gameObject.GetComponent<enemy>().health -= damage;
                collision.gameObject.GetComponent<enemy>().ismoving =true;
                collision.gameObject.GetComponent<enemy>().dir=Player.Instance.facingdir*(-1);
                collision.gameObject.GetComponent<enemy>().step= (collision.gameObject.GetComponent<enemy>().currentposition-Player.Instance.currentposition)*Player.Instance.facingdir-1;
                Player.Instance.hookattached = true;
                Destroy(gameObject);
            }
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

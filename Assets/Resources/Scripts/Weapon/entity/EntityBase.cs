using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviour
{
    public int range;
    public int damage;
    public int startposition;
    public int targetposition;
    public Rigidbody2D rb;
    // Start is called before the first frame update
     public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startposition = Player.Instance.currentposition;
        if (Player.Instance.facingdir > 0) 
        {
            for(int i = startposition+range; i > startposition; i--) 
            {
                if (GameObject.Find("platform" + i) != null) 
                {
                    targetposition = i;
                    
                    break;
                }
            }
        }
        else 
        {
            for (int i = startposition-range; i < startposition; i++)
            {
                if (GameObject.Find("platform" + i) != null)
                {
                    targetposition = i;
                    break;
                }
            }
        }
        if (targetposition == 0) 
        {
            Debug.Log("notarget");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        function();
    }
    public virtual void function() 
    {
        rb.velocity = new Vector2(20*Player.Instance.facingdir,0);
        if((transform.position.x>=GameObject.Find("platform"+targetposition).transform.position.x&&Player.Instance.facingdir==1)|| (transform.position.x <= GameObject.Find("platform" + targetposition).transform.position.x && Player.Instance.facingdir == -1)) 
        {
            Destroy(gameObject);
        }
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (!collision.GetComponent<enemy>().dead) 
            {
            collision.gameObject.GetComponent<enemy>().health -= damage;
            Debug.Log("attach");
            Destroy(gameObject);
            }
        }
    }
}

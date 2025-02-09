using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseend : MonoBehaviour
{
    public getObjectController gocins;
    public GameObject tiptxt;
    public float time;
    public bool tiping;

    public void pressed() 
    {
        if (Player.Instance.Weaponbackpack.Count == 0) 
        {
            tiptxt.SetActive(true);
            tiping = true;
        }
        else 
        {
        for(int i = 0; i <GameObject.Find("mask").GetComponent<getObjectController>().choosetransforms.Count && i < Player.Weaponbag.Count; i++) 
        {
        if(GameObject.Find("mask").GetComponent<getObjectController>().transform.Find("choose" + Player.Weaponbag[i] + "(Clone)") != null) 
            {
                Destroy(GameObject.Find("mask").GetComponent<getObjectController>().transform.Find("choose" + Player.Weaponbag[i] + "(Clone)").gameObject);
            }
        }
        GameObject.Find("levelmanager").GetComponent<levelmanager>().choosecard = false;
        gameObject.SetActive(false);
        }
    }
    public void Update()
    {
        if (tiping) 
        {
            time += Time.deltaTime;
            if (time > 1f) 
            {
                time = 0;
                tiping = false;
                tiptxt.SetActive(false);
            }
        }   
    }
}

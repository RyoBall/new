using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseend : MonoBehaviour
{
    public getObjectController gocins;
    public void pressed() 
    {
        for(int i = 0; i <GameObject.Find("mask").GetComponent<getObjectController>().choosetransforms.Count && i < Player.Weaponbag.Count; i++) 
        {
        if(GameObject.Find("mask").GetComponent<getObjectController>().transform.Find("choose" + Player.Weaponbag[i] + "(Clone)") != null) 
            {
                Destroy(GameObject.Find("mask").GetComponent<getObjectController>().transform.Find("choose" + Player.Weaponbag[i] + "(Clone)").gameObject);
            }
        }
        GameObject.Find("levelmanager").GetComponent<levelmanager>().choosecard = false;
        Destroy(gameObject);
    }
}

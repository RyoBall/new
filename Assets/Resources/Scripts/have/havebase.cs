using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.U2D.Animation;
#endif
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class havebase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isWeapon;
    public float onmousetime;
    public bool onmouse;
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        onmouse = true;
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        onmouse = false;
        onmousetime = 0;
        GetComponentInChildren<iconbackgroundbase>(true).gameObject.SetActive(false);
    }
    public virtual void pressed(string name)
    {
        Player.Wholebackpack.Add(name);
        if (!isWeapon)
            Player.Objectbag.Add(name);
        else 
        {
            Player.Weaponbag.Add(name);
            Debug.Log(name);
        }
        Debug.Log("havechosen");
        if(!isWeapon)
        SceneManager.LoadScene("level" + (GameObject.Find("levelmanager").GetComponent<levelmanager>().currentlevel + 1));
        else 
        {
           GameObject.Find("mask").GetComponent<getObjectController>().winGenerate = 2;
            for(int j = 0; j < 3; j++) 
            {
                for (int i = 0; i < Player.Instance.Weaponobject.Count; i++) 
                {
                    if (GameObject.Find("mask").GetComponent<getObjectController>().transforms[j].Find("have"+Player.Instance.Weaponobject[i]+"(Clone)") != null) 
                    {
                        Destroy(GameObject.Find("mask").GetComponent<getObjectController>().transforms[j].Find("have" + Player.Instance.Weaponobject[i] + "(Clone)").gameObject);
                    }
                }
            }
        }
    }
    public virtual void Update()
    {
        if (onmouse)
            onmousetime += Time.deltaTime;
        if (onmousetime > 0.5f)
        {
            GetComponentInChildren<iconbackgroundbase>(true).gameObject.SetActive(true);
        }
    }
}

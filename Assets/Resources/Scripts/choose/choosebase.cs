using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class choosebase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool chosen;
    public bool onmouse;
    public float onmousetime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(onmouse)
        onmousetime += Time.deltaTime;
        if (onmousetime > 0.5f)
        {
            GetComponentInChildren<iconbase>(true).gameObject.SetActive(true);
        }
    }
    public virtual void pressed(string name) 
    {
        Debug.Log(Player.Instance.Weaponbackpack.Count);   
        if (!chosen) 
        {
            if (Player.Instance.Weaponbackpack.Count <= 4) 
            {
                chosen = true;
                Player.Instance.Weaponbackpack.Add(name);
            }
            else
                Debug.Log("enoughweapon");
        }
        else 
        {
            chosen=false;
            Player.Instance.Weaponbackpack.Remove(name);
        }
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        onmouse = true;
        Debug.Log(121);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        onmouse = false;
        onmousetime = 0;
        GetComponentInChildren<iconbase>(true).gameObject.SetActive(false);
    }
}

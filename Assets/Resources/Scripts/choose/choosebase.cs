using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class choosebase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool chosen;
    public bool generated;
    public bool onmouse;
    public float onmousetime;

    [SerializeField] GameObject selected;
    // Start is called before the first frame update
    void Start()
    {
        chosen = false;
        selected .SetActive(false);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (!generated) 
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0.5f);
            generated = true;
        }
        if(onmouse)
        onmousetime += Time.deltaTime;
        if (onmousetime > 0.5f)
        {
            GetComponentInChildren<iconbackgroundbase>(true).gameObject.SetActive(true);
        }

        if (chosen)
        {
            selected.SetActive(true);
        }
        else selected.SetActive(false); 
    }
    public virtual void pressed(string name) 
    {
        if (!chosen) 
        {
            if (Player.Instance.Weaponbackpack.Count < 4) 
            {
                chosen = true;
                Player.Instance.Weaponbackpack.Add(name);
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
            }
            else 
            {
                
            }
        }
        else 
        {
            chosen=false;
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0.5f);
            Player.Instance.Weaponbackpack.Remove(name);
        }
        Debug.Log(Player.Instance.Weaponbackpack.Count);   
    }

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
}

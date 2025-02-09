using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class gettingsword : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float onmousetime;
    public bool onmouse;
    public void OnPointerExit(PointerEventData eventData)
    {
        onmousetime = 0;
        onmouse = false;
        GetComponentInChildren<iconbackgroundbase>(true).gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onmouse = true;
    }
    void Update()
    {
        if (onmouse) 
        {
            onmousetime += Time.deltaTime;
        }
        if (onmousetime > 0.5f)
        {
            GetComponentInChildren<iconbackgroundbase>(true).gameObject.SetActive(true);
        }
    }
    public void pressed()
    {
        if (!levelmanager.dicing)
        {
            Player.Instance.actions.Add("sword");
            Player.Instance.stepturns = 0;
        }
        else
        {
            Player.Instance.actions[levelmanager.dicingstep-1] = "sword";
            levelmanager.dicing = false;
            levelmanager.stepgo();
        }
    }
}

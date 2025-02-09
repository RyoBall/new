using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class gettingSpring : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
        Player.Instance.actions.Add("spring");
        Player.Instance.stepturns = 0;
    }
}

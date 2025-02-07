using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class gettingdice : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float onmousetime;
    public bool onmouse;
    public void OnPointerExit(PointerEventData eventData)
    {
        onmousetime = 0;
        onmouse = false;
        GetComponentInChildren<iconbase>(true).gameObject.SetActive(false);
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
            GetComponentInChildren<iconbase>(true).gameObject.SetActive(true);
            GetComponentInChildren<iconbackgroundbase>(true).gameObject.SetActive(true);
        }
    }
    public void pressed()
    {
        Player.Instance.actions.Add("dice");
        Player.Instance.stepturns = 0;
    }
}

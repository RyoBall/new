using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class havechanger : havebase
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        onmouse = true;
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        onmouse = false;
        onmousetime = 0;
        GetComponentInChildren<iconbackgroundbase>(true).gameObject.SetActive(false);
    }
   
    public void Start()
    {
        isWeapon = false;
    }
    public override void pressed(string name)
    {
        base.pressed("changer");
    }

    public override void Update()
    {
        base.Update();
    }
}

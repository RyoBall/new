using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class havelightning : havebase
{
   
    public void Start()
    {
        isWeapon = false;
    }
    public override void pressed(string name)
    {
        base.pressed("lightning");
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
    }

    public override void Update()
    {
        base.Update();
    }
}

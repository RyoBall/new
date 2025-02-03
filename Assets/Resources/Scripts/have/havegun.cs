    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class havegun : havebase
{

    public void Start()
    {
        isWeapon = true;
    }
    public override void pressed(string name)
    {
        base.pressed("gun");
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

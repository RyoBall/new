using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class chooseelectricburst : choosebase
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
    }

    public override void pressed(string name)
    {
        base.pressed("electricburst");
    }

    public override void Update()
    {
        base.Update();
    }
}

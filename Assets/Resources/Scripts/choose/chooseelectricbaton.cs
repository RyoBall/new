using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class chooseelectricbaton : choosebase
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
        base.pressed("electricbaton");
    }

    public override void Update()
    {
        base.Update();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class choosedeffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (GetComponentInParent<stepButton>() != null&& GetComponentInParent<stepButton>().bestepped) 
        {
            ;
        }
        else
        transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.25f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (GetComponentInParent<stepButton>() != null && GetComponentInParent<stepButton>().bestepped)
        {
            ;
        }
        transform.DOScale(new Vector3(1, 1, 1), 0.25f);
    }
}

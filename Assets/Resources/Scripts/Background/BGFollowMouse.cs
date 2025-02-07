using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGFollowMouse : MonoBehaviour
{
    [SerializeField] float power;
    [SerializeField] Image bg;

    private RectTransform bgTr;
    private Canvas canvas;
    private Vector2 uiMousePosition;
    private Vector2 offset;

    private Vector2 midPos;
    // Start is called before the first frame update
    void Start()
    {
        bgTr = bg.rectTransform;
        canvas = GetComponentInParent<Canvas>();
        midPos.x = Screen.width / 2;
        midPos.y = Screen.height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        offset.x = Input.mousePosition.x - midPos.x;
        offset.y = Input.mousePosition.y - midPos.y;

        Vector3 worldPos = Camera .main .ScreenToWorldPoint(midPos - offset * power);
        uiMousePosition = canvas.transform.InverseTransformPoint(worldPos);

        bgTr.anchoredPosition = uiMousePosition;
    }
}

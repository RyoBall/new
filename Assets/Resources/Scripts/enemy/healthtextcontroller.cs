using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthtextcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponentInChildren<TMPro.TMP_Text>().text = GetComponentInParent<enemy>().health + "/" + GetComponentInParent<enemy>().healthmax;
    }
}

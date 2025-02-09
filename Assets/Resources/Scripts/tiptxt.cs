using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiptxt : MonoBehaviour
{
    public bool tiping;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tiping)
        {
            time += Time.deltaTime;
            if (time > 1f)
            {
                time = 0;
                tiping = false;
                gameObject.SetActive(false);
            }
        }
    }
}

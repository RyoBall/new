using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heimucontroller : MonoBehaviour
{
    public float loadingtime;
    public bool loaded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Image>().color.a >= 0.8)
        {
            loaded = true;
        }
        else 
        {
            loaded = false;
        }
        loadingtime += Time.deltaTime;


            if (((Player.Instance.stepturns==-1 || levelmanager.dicing || levelmanager.dicingchoose) &&loadingtime > 0.04f)&& GetComponent<Image>().color.a<=0.8)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, GetComponent<Image>().color.a + 0.1f);
            loadingtime = 0;
        }
        else if (Player.Instance.stepturns != -1||(!levelmanager.dicingchoose&&levelmanager.dicing)) 
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicmanager : MonoBehaviour
{
    public bool setingamemusic;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("levelmanager").GetComponent<levelmanager>().choosecard&& !GameObject.Find("levelmanager").GetComponent<levelmanager>().win&&!setingamemusic) 
        {
            setingamemusic = true;
            GetComponent<AudioSource>().loop=true;
            GetComponent<AudioSource>().clip=Resources.Load<AudioClip>("effect/ingame");
            GetComponent<AudioSource>().Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricsystem : MonoBehaviour
{
    public List<GameObject> electrics = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i =0; i < Player.Instance.health; i++) 
        {
            electrics[i].SetActive(true);
        }
        for(int i = (int)(Player.Instance.health); i < 8; i++) 
        {
            electrics[i].SetActive(false);
        }
    }
}

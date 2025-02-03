using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class diceaction : MonoBehaviour
{
    public int actionstep;//代表第几个武器
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("icon/" + Player.Instance.actions[actionstep]+"-export");   
    }

    // Update is called once per frame
    void Update()
    {
        if (levelmanager.dicing) 
        {
            Destroy(gameObject);
        }
    }
    public void pressed() 
    {
        levelmanager.dicingstep = actionstep;
        levelmanager.dicingchoose=false;
        levelmanager.dicing=true;
       GameObject.Find("mask").GetComponent<getObjectController>().choiceGenerate = false;
    }
}

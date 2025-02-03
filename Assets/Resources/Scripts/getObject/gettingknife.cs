using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gettingknife : MonoBehaviour
{
    public float onmousetime;
    private void OnMouseOver()
    {
        onmousetime += Time.deltaTime;
        if (onmousetime > 0.5f)
        {
            GetComponentInChildren<iconbase>(true).gameObject.SetActive(true);
        }
    }
    private void OnMouseExit()
    {
        onmousetime = 0;
        GetComponentInChildren<iconbase>(true).gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pressed() 
    {
        if (!levelmanager.dicing)
        {
            Player.Instance.actions.Add("knife");
            Player.Instance.stepturns = 0;
        }
        else
        {
            Player.Instance.actions[levelmanager.dicingstep] = "knife";
            levelmanager.dicing = false;
            levelmanager.stepgo();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gettingelectricburst : MonoBehaviour
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
    public void pressed()
    {
        if (!levelmanager.dicing)
        {
            Player.Instance.actions.Add("electricburst");
            Player.Instance.stepturns = 0;
        }
        else
        {
            Player.Instance.actions[levelmanager.dicingstep] = "electricburst";
            levelmanager.dicing = false;
            levelmanager.stepgo();
        }
    }
}

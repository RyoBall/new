using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gettingcharger : MonoBehaviour
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
        Player.Instance.actions.Add("changer");
        Player.Instance.stepturns = 0;
    }
}

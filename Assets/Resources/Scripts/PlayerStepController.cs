using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStepController : MonoBehaviour
{
    public Image currentstep;
    // Start is called before the first frame update
    void Start()
    {
        currentstep = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Instance.stepturns > 0 && Player.Instance.stepturns < 5) 
        {
            ;
        }
        else 
        {
                currentstep.gameObject.SetActive(false);
        }
        if (GameObject.Find("step" + Player.Instance.stepturns) != null) 
        {
            if (GameObject.Find("step" + Player.Instance.stepturns).GetComponent<stepButton>().stepname != null) 
            {
               currentstep.gameObject.SetActive(true);
               currentstep.sprite=Resources.Load<Sprite>("icon/"+GameObject.Find("step" + Player.Instance.stepturns).GetComponent<stepButton>().stepname+"-export");
            }
            else 
            {
                currentstep.gameObject.SetActive(false);
            }
        }
    }
}

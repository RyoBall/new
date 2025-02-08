using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackedeffect : MonoBehaviour
{
    public bool swordeffect;
    public bool hugeswordeffect;
    public Animator anim;
    private void Update()
    {
        anim.SetBool("sword", swordeffect);
    }
    public void swordfinish() 
    {
        swordeffect = false;
    }
}

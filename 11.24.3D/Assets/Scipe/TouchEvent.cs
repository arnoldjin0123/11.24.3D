using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEvent : MonoBehaviour
{
    public Animator NPCAni;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag=="Talking")
        {
            NPCAni.SetBool("Talking", true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag=="Talking")
        {
            NPCAni.SetBool("Talking", false);
        }
    }
}

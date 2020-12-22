using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchEvent : MonoBehaviour
{
    public Animator NPCAni;
    public GameObject TalkingPanel;
    public Text NPCName;
    public string ThisNPCName;
    public NPCData NPCDaiolouge;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag=="MainCharacter")
        {
            NPCAni.SetBool("Talking", true);
            TalkingPanel.SetActive (true);
            NPCName.text = ThisNPCName;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag== "MainCharacter")
        {
            NPCAni.SetBool("Talking", false);
            TalkingPanel.SetActive(false);
        }
    }
}

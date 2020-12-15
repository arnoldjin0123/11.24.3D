using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchEvent : MonoBehaviour
{
    public Animator NPCAni;
    public GameObject TalkingPanel;
    public Text NPCName;
    public NPCData NPCDaiolouge;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag=="Talking")
        {
            NPCAni.SetBool("Talking", true);
            TalkingPanel.SetActive (true);
            NPCName.text = "Green cloth's villagers";
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag=="Talking")
        {
            NPCAni.SetBool("Talking", false);
            TalkingPanel.SetActive(false);
        }
    }
}

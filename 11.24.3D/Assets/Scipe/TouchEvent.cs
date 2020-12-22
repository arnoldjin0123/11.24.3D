using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchEvent : MonoBehaviour
{
    [Header("Talking panel")]
    public GameObject TalkingPanel;
    [Header("NPC's data")]
    public Animator NPCAni;
    public string ThisNPCName;
    public Text NPCName;
    public Text DaiolougeText;
    public NPCData NPCDaiolouge;
    [Header("Word display speed")]
    public float TalkingSpeed=0.1f;

    private bool NPCTalking = false;
    private bool SkipTalking = false;
    private int DaiolougeFinish = 0;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag=="MainCharacter")
        {

            NPCAni.SetBool("Talking", true);
            TalkingPanel.SetActive (true);
            DaiolougeText.text = "";
            NPCName.text = ThisNPCName;
            StartCoroutine(Diolouge1Saying());
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "MainCharacter")
        {
            NPCAni.SetBool("Talking", false);
            TalkingPanel.SetActive(false);
            StopAllCoroutines();
        }
    }

    private IEnumerator Diolouge1Saying()
    {
        DaiolougeText.text = "";
        NPCTalking = true;
        for (int i = 0; i < NPCDaiolouge.Daiolouge1.Length; i++)
        {
            DaiolougeText.text += NPCDaiolouge.Daiolouge1[i] + "";

            if (SkipTalking == true)
            {
                DaiolougeText.text = NPCDaiolouge.Daiolouge1;
                SkipTalking = false;
                Debug.Log("Mouse right click bool false");

                DaiolougeFinish = 1;
                Debug.Log("Finish daiolouge1");

                NPCTalking = false;
                Debug.Log("NPC end talking");
                yield break;
            }
            yield return new WaitForSeconds(TalkingSpeed);
        }
        SkipTalking = false;

        NPCTalking = false;
        Debug.Log("NPC end talking");

        DaiolougeFinish = 1;
        Debug.Log("Finish daiolouge1");
    }

    private IEnumerator Diolouge2Saying()
    {
        DaiolougeText.text = "";
        NPCTalking = true;

        for (int i = 0; i < NPCDaiolouge.Daiolouge2.Length; i++)
        {
            DaiolougeText.text += NPCDaiolouge.Daiolouge2[i] + "";

            if (SkipTalking == true)
            {
                DaiolougeText.text = NPCDaiolouge.Daiolouge2;
                SkipTalking = false;
                Debug.Log("Mouse right click bool false");

                DaiolougeFinish = 2;
                Debug.Log("Finish daiolouge2");

                NPCTalking = false;
                Debug.Log("NPC end talking");
                yield break;
            }
            yield return new WaitForSeconds(TalkingSpeed);
        }
        SkipTalking = false;

        NPCTalking = false;
        Debug.Log("NPC end talking");

        DaiolougeFinish = 2;
        Debug.Log("Finish daiolouge2");
    }

    private IEnumerator Diolouge3Saying()
    {
        DaiolougeText.text = "";
        NPCTalking = true;

        for (int i = 0; i < NPCDaiolouge.Daiolouge3.Length; i++)
        {
            DaiolougeText.text += NPCDaiolouge.Daiolouge3[i] + "";

            if (SkipTalking == true)
            {
                DaiolougeText.text = NPCDaiolouge.Daiolouge3;
                SkipTalking = false;
                Debug.Log("Mouse right click bool false");

                DaiolougeFinish = 3;
                Debug.Log("Finish daiolouge3");

                NPCTalking = false;
                Debug.Log("NPC end talking");
                yield break;
            }
            yield return new WaitForSeconds(TalkingSpeed);
        }
        SkipTalking = false;

        NPCTalking = false;
        Debug.Log("NPC end talking");

        DaiolougeFinish = 3;
        Debug.Log("Finish daiolouge3");
    }

    private void Update()
    {
        if (NPCTalking=true && Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Mouse right click");
            SkipTalking = true;
        }



        if (DaiolougeFinish == 1 && Input.GetKeyDown(KeyCode.Mouse1) && SkipTalking == false)
        {
            StartCoroutine(Diolouge2Saying());
        }

        if (DaiolougeFinish == 2 && Input.GetKeyDown(KeyCode.Mouse1) && SkipTalking == false)
        {
            StartCoroutine(Diolouge3Saying());
        }
    }
}

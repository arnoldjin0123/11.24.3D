using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchEvent1 : MonoBehaviour
{
    [Header("TalkingPanel")]
    public GameObject TalkingPanel;

    [Header("NPC Data")]
    public string ThisNPCName;
    public Text NpcName;
    public NPCData NPCDaiolouge;
    public Text DaiolougeText;
    public Animator NpcAni;

    [Header("SpeakingSpeed")]
    public float TalkingSpeed = 0.1f;

    // Skip Reading bool
    private bool NPCTalking = false;
    private bool SkipTalking = false;
    private bool SkipTalkingGate = false;
    private int DaiolougeFinish = 0;

    // Player T/F in talking area
    private bool InTalkingArea=false;

    //Player in talking area
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "MainCharacter")
        {
            InTalkingArea = true;
            NpcAni.SetBool("Talking", true);
        }
    }
    //Player out talking area
    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "MainCharacter")
        {
            InTalkingArea = false;
            NpcAni.SetBool("Talking", false);
            TalkingPanel.SetActive(false);
            DaiolougeText.text = "";
            StopCoroutine(Daiolouge1Saying());
            DaiolougeFinish = 0;
        }
    }

    void Start()
    {
        NpcName.text = ThisNPCName;
    }

    void Update()
    {
        //Enter talking area and right click to open daiolouge pannel and start talking
        if (InTalkingArea==true && Input.GetKeyDown(KeyCode.Mouse1) 
            && NPCTalking == false && SkipTalking == false 
            && DaiolougeFinish == 0)
        {
            Debug.Log("OpenPanel");
            TalkingPanel.SetActive(true);
            StartCoroutine(Daiolouge1Saying());
        }
        //Npc is talking if right click skip to finish
        //SkipTalking =true
        if (NPCTalking == true && SkipTalking == false
            && InTalkingArea == true && SkipTalkingGate == true
            &&Input.GetKeyDown(KeyCode.Mouse1))
        {
            SkipTalking = true;
            Debug.Log("Skip talking bool on");
        }

        if (DaiolougeFinish==1 && NPCTalking == false 
            && SkipTalking == false && Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartCoroutine(Daiolouge2Saying());
        }

        if (DaiolougeFinish == 2 && NPCTalking == false
            && SkipTalking == false && Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartCoroutine(Daiolouge3Saying());
        }
        if (DaiolougeFinish == 3 && NPCTalking == false
            && SkipTalking == false && Input.GetKeyDown(KeyCode.Mouse1))
        {
            TalkingPanel.SetActive(false);
        }
    }

    private IEnumerator Daiolouge1Saying()
    {
        Debug.Log("Daiolouge 1 start");
        DaiolougeText.text = "";
        //NPC is talking
        NPCTalking = true;
        for (int i = 0; i < NPCDaiolouge.Daiolouge1.Length; i++)
        {
            //If i>1 can skip the playing word
            //Open SkipTalkingGate
            if (i>1)
            {
                SkipTalkingGate = true;
                Debug.Log("SkipTalking can open");
            }
            DaiolougeText.text += NPCDaiolouge.Daiolouge1[i] + "";
            //If Skiptalking on and NPC still talking, skip the playing word
            //and clsoe SkipTalkingGate, SkipTalking, NPCTalking
            //DaiolougeFinsh = 1
            if (SkipTalking == true && NPCTalking == true)
            {
                DaiolougeText.text = NPCDaiolouge.Daiolouge1;
                SkipTalkingGate = false;
                Debug.Log("Can't skip talking");
                SkipTalking = false;
                Debug.Log("Skip");
                DaiolougeFinish = 1;
                Debug.Log("Finish daiologe 1");
                NPCTalking = false;
                Debug.Log("NPC end daiolouge 1");
                yield break;
            }
            yield return new WaitForSeconds(TalkingSpeed);
        }
        SkipTalkingGate = false;
        Debug.Log("Can't skip talking");
        SkipTalking = false;
        Debug.Log("Can't skip");
        NPCTalking = false;
        Debug.Log("NPC complete end daiolouge 1");
        DaiolougeFinish = 1;
        Debug.Log("Complete finish daiolougr 1");
    }

    private IEnumerator Daiolouge2Saying()
    {
        Debug.Log("Daiolouge 2 start");
        DaiolougeText.text = "";
        //NPC is talking
        NPCTalking = true;
        for (int i = 0; i < NPCDaiolouge.Daiolouge2.Length; i++)
        {
            //If i>1 can skip the playing word
            //Open SkipTalkingGate
            if (i > 1)
            {
                SkipTalkingGate = true;
                Debug.Log("SkipTalking can open");
            }
            DaiolougeText.text += NPCDaiolouge.Daiolouge2[i] + "";
            //If Skiptalking on and NPC still talking, skip the playing word
            //and clsoe SkipTalkingGate, SkipTalking, NPCTalking
            //DaiolougeFinsh = 1
            if (SkipTalking == true && NPCTalking == true)
            {
                DaiolougeText.text = NPCDaiolouge.Daiolouge2;
                SkipTalkingGate = false;
                Debug.Log("Can't skip talking");
                SkipTalking = false;
                Debug.Log("Skip");
                DaiolougeFinish = 2;
                Debug.Log("Finish daiologe 1");
                NPCTalking = false;
                Debug.Log("NPC end daiolouge 1");
                yield break;
            }
            yield return new WaitForSeconds(TalkingSpeed);
        }
        SkipTalkingGate = false;
        Debug.Log("Can't skip talking");
        SkipTalking = false;
        Debug.Log("Can't skip");
        NPCTalking = false;
        Debug.Log("NPC complete end daiolouge 2");
        DaiolougeFinish = 2;
        Debug.Log("Complete finish daiolougr 2");
    }

    private IEnumerator Daiolouge3Saying()
    {
        Debug.Log("Daiolouge 3 start");
        DaiolougeText.text = "";
        //NPC is talking
        NPCTalking = true;
        for (int i = 0; i < NPCDaiolouge.Daiolouge3.Length; i++)
        {
            //If i>1 can skip the playing word
            //Open SkipTalkingGate
            if (i > 1)
            {
                SkipTalkingGate = true;
                Debug.Log("SkipTalking can open");
            }
            DaiolougeText.text += NPCDaiolouge.Daiolouge3[i] + "";
            //If Skiptalking on and NPC still talking, skip the playing word
            //and clsoe SkipTalkingGate, SkipTalking, NPCTalking
            //DaiolougeFinsh = 1
            if (SkipTalking == true && NPCTalking == true)
            {
                DaiolougeText.text = NPCDaiolouge.Daiolouge3;
                SkipTalkingGate = false;
                Debug.Log("Can't skip talking");
                SkipTalking = false;
                Debug.Log("Skip");
                DaiolougeFinish = 3;
                Debug.Log("Finish daiologe 3");
                NPCTalking = false;
                Debug.Log("NPC end daiolouge 3");
                yield break;
            }
            yield return new WaitForSeconds(TalkingSpeed);
        }
        SkipTalkingGate = false;
        Debug.Log("Can't skip talking");
        SkipTalking = false;
        Debug.Log("Can't skip");
        NPCTalking = false;
        Debug.Log("NPC complete end daiolouge 1");
        DaiolougeFinish = 3;
        Debug.Log("Complete finish daiolougr 1");
    }
}

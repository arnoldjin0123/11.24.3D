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
    private int DaiolougeFinish = 0;
    // Player in talking area
    private bool InTalkingArea=false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "MainCharacter")
        {
            InTalkingArea = true;
            NpcAni.SetBool("Talking", true);
        }
    }

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

    // Start is called before the first frame update
    void Start()
    {
        NpcName.text = ThisNPCName;
    }

    // Update is called once per frame
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
        if (NPCTalking == true && SkipTalking == false
            && InTalkingArea == true && Input.GetKeyDown(KeyCode.Mouse1))
        {
            SkipTalking = true;
            Debug.Log("Skip talking bool on");
        }


    }

    private IEnumerator Daiolouge1Saying()
    {
        Debug.Log("Daiolouge 1 start");
        DaiolougeText.text = "";
        NPCTalking = true;
        for (int i = 0; i < NPCDaiolouge.Daiolouge1.Length; i++)
        {
            Debug.Log("Print 1 word");
            DaiolougeText.text += NPCDaiolouge.Daiolouge1[i] + "";
            if (i>5 && SkipTalking == true && NPCTalking == true)
            {
                DaiolougeText.text = NPCDaiolouge.Daiolouge1;
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
        SkipTalking = false;
        Debug.Log("Can't skip");
        NPCTalking = false;
        Debug.Log("NPC complete end daiolouge 1");
        DaiolougeFinish = 1;
        Debug.Log("Complete finish daiolougr 1");
    }

}

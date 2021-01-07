using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    public GameObject SkyGround;
    public Animator MonsterANI;
    public GameObject Monster;
    [Header("MonstorMoveSpeed")]
    public float MonsterSpeed = 0f;
    private bool LetMonsterWalk=false;
    private void Update()
    {
        if (LetMonsterWalk==true)
        {
            MonsterWalking();
        }
        if (  )
        {
            MonsterStop();
            LoadLevel();
        }
    }
    public void GameStartEvent()
    {
        SkyGround.SetActive(false);
        MonsterANI.SetBool("Run", true);
        LetMonsterWalk = true;
    }
    private void MonsterWalking()
    {
        Monster.transform.Translate(0, 0, MonsterSpeed);
    }
    private void MonsterStop()
    {
        LetMonsterWalk = false;
        MonsterANI.SetTrigger("Attack");

    }
    private void LoadLevel()
    {
        SceneManager.LoadScene("BaseLevel");
    }
}

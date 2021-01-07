using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCombo : MonoBehaviour
{
    public Animator DogAni;
    private int ComboCounter = 0;

    public float Timer = 0f;

    public float Combo1CDTime = 93f;
    public float Combo2CDTime = 158f;
    public float Combo3CDTime = 83f;

    private bool ComboBool = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ComboBool = true;
            Combo();
        }
    }

    void ComboCDTime()
    {
        Timer += Time.deltaTime;
    }

    private void Combo()
    {
        ComboCounter += 1;
        ComboBool = false;
        if (ComboCounter == 1)
        {
            DogAni.SetInteger("Combo", ComboCounter);
            ComboCDTime();
        }


        if (ComboCounter == 2)
        {
            DogAni.SetInteger("Combo", ComboCounter);
            ComboCDTime();
        }
        if (Timer == Combo1CDTime)
        {
            ComboCounter = 0;
            Timer = 0;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCombo : MonoBehaviour
{
    public Animator DogAni;
    private int ComboTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Timer4", 0.1f, 0.01f);
    }

    void Timer4()
    {
        if (ComboTimer == 0)
        {
            return;
        }

        if (ComboTimer > 0)
        {
            ComboTimer -= 1;
            Debug.Log(ComboTimer);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            DogAni.SetInteger("Combo", 1);
            ComboTimer = 92;

            if (Input.GetKey(KeyCode.Mouse0))
            {
                DogAni.SetInteger("Combo", 2);
                ComboTimer = 158;

                if (Input.GetKey(KeyCode.Mouse0))
                {
                    DogAni.SetInteger("Combo", 83);
                    ComboTimer = 83;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCombo : MonoBehaviour
{
    public Animator DogAni;
    private int ComboCounter = 0;

    // Start is called before the first frame update
    void Start()
    { 

    }
    void Update()
    {
        DogAni.SetInteger("Combo", ComboCounter);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("MouseClick");
            ComboCounter = ComboCounter+1;
            Debug.Log("Combo+1");
        }

    }
}

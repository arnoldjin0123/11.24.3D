using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMonsterTouchEvent : MonoBehaviour
{
    public bool MonsterHit = false;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name== "MonsterStop")
        {
            MonsterHit = true;
        }
    }

}

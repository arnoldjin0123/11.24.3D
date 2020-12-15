using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NPC data", menuName ="NPC data/talking detail")]
public class NPCData : ScriptableObject
{
    [Header("First daiolouge"), TextArea(1,8)]
    public string Daiolouge1;
    [Header("Scond daiolouge"), TextArea(1, 8)]
    public string Daiolouge2;
    [Header("Thrid daiolouge"), TextArea(1, 8)]
    public string Daiolouge3;
    [Header("Mission target val")]
    public string MissionTargetVal;
    [Header("Your mission target val")]
    public string YourTargetVal;
}

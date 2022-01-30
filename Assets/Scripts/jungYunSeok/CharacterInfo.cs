using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CharacterInfo", menuName ="CharacterFolder/ACharacterInfo")]
public class CharacterInfo: ScriptableObject
{
    public bool isStriker;
    public bool isSupporter;

    public int Character_ID;
    public string Character_Name;
    public int Health;
    public int Speed;
    public string Characteristic;
    public string Character_Detail;
}
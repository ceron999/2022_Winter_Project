using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Characters : MonoBehaviour
{
    public int character_id;
    public string character_name;
    public int health;
    public int speed;
    public string characteristic;
    public string character_detail;

    public Characters()
    {

    }

    public Characters(int Character_ID, string Character_Name, int Health, int Speed, string Characteristic, string Character_Detail)
    {
        character_id = Character_ID;
        character_name = Character_Name;
        health = Health;
        speed = Speed;
        characteristic = Characteristic;
        character_detail = Character_Detail;
    }
}

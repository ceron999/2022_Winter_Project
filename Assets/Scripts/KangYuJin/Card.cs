using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card : MonoBehaviour
{
    public int card_number;
    public string card_name;
    public int damage;
    public int card_cooldown;
    public string card_detail;
    public bool supposrt;

    public Card()
    {

    }

    public Card(int Card_Namber, string Card_Name, int Damage, int Card_Cooldown, string Card_Detail, bool Supposrt)
    {
        card_number = Card_Namber;
        card_name = Card_Name;
        damage = Damage;
        card_cooldown = Card_Cooldown;
        card_detail = Card_Detail;
        supposrt = Supposrt;
    }
}

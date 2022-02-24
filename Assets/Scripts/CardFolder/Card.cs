using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Card
{
    public int cardNumber;
    public string cardName;
    public int damage;
    public int cardCooldown;
    public string cardDetail;
    public int[] damageRange;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardInfo : MonoBehaviour
{
    public bool isSupporterCard;
    public int cardNumber;
    public string cardName;
    public int damage; 
    public int cardCooldown;
    public string cardDetail;
    //Damage_Range;

    //사용시 적용되는 스킬 함수
}

[CreateAssetMenu(fileName = "CardSO", menuName = "CardFolder/CardSO")]
public class CardSO:ScriptableObject
{
    public CardInfo[] cards;
}

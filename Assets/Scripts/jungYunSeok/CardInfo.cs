using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardInfo", menuName = "CardFolder/CardInfo")]
public class CardInfo : ScriptableObject
{
    public bool isSupporterCard;

    public int cardNumber;
    public string cardName;
    public int damage; 
    public int Card_Cooldown;
    public string Card_Detail;
    //Damage_Range;

    //���� ����Ǵ� ��ų �Լ�
}

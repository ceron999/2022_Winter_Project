using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(1, "카드1", 10, 1, "가", false));
        cardList.Add(new Card(2, "카드2", 20, 2, "나", false));
        cardList.Add(new Card(3, "카드3", 30, 3, "다", false));
        cardList.Add(new Card(4, "카드4", 40, 4, "라", false));
        cardList.Add(new Card(5, "카드5", 50, 5, "마", false));
    }
}

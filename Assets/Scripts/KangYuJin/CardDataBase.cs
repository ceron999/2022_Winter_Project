using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(1, "ī��1", 10, 1, "��", false));
        cardList.Add(new Card(2, "ī��2", 20, 2, "��", false));
        cardList.Add(new Card(3, "ī��3", 30, 3, "��", false));
        cardList.Add(new Card(4, "ī��4", 40, 4, "��", false));
        cardList.Add(new Card(5, "ī��5", 50, 5, "��", false));
    }
}

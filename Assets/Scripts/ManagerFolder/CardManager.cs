using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] CardInfo cardData;
    public List<GameObject> cardQueue;
    public static CardManager cardManager;
    public Sprite[] sprites;
    public GameObject StrikerSkillBTN;

    void Start()
    {
        if (cardManager == null)
        {
            cardManager = this;
            sprites = Resources.LoadAll<Sprite>("CardOrder"); //Resources 폴더의 Sprites/Cardorder 의 이미지 불러서 배열에 저장.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeOrderImg() // 모든 큐에 대해 이미지 다시 불러옴.
    {
        for (int i = 0; i < cardQueue.Count; i++)
        {
            //막힘... Striker(Support)SkillBTN+cardQueue[i].Reorder() 이런식으로 해야되는데... 어케함?
            cardQueue[i].GetComponent<CardInfo>().ReOrder();
        }
    }

}

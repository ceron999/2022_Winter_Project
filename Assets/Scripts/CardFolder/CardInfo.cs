using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] CardManager cardMgr;
    public bool isSelected = false;
    public GameObject cardObj;
    public GameObject cardOrder;
    public GameObject cardOrderImg;
    public SpriteRenderer cardOrderSpriter;
    List<GameObject> order;

    private void Awake()
    {
        order = cardMgr.cardQueue;

        cardOrderImg = Instantiate(cardOrder, transform); // 카드 오른쪽 상단에 image 생성 후 안보이게 함.
        Vector2 position = new Vector2(60, 60);
        cardOrderImg.transform.localPosition = position;
        cardOrderImg.SetActive(false);
        cardOrderSpriter = cardOrderImg.GetComponent<SpriteRenderer>();
    }

    public void SelectCard()
    {
        if (isSelected)
        {
            order.Remove(cardObj); //해당 카드의 번호 큐에서 삭제
            cardOrderImg.SetActive(false); // 이미지 없앰.
            cardMgr.ChangeOrderImg();
            isSelected = false;
        }
        else
        {
            if (order.Count > 3) return; // 카드가 세 개 선택 된 경우 동작하지 않음.
            // 큐의 마지막 인덱스 번호 = 카드 번호. 해당 번호의 이미지 불러옴.
            cardOrderImg.GetComponent<Image>().sprite = cardMgr.sprites[order.Count];
            cardOrderImg.SetActive(true);// 이미지 나타나게 함.
            order.Add(cardObj); // 해당 카드 번호 큐에 삽입
            isSelected = true;
        }
    }

    public void ReOrder()
    {
        cardOrderImg.GetComponent<Image>().sprite = cardMgr.sprites[order.IndexOf(cardObj)]; // 큐에서 자기 인덱스 번호의 이미지로 변경.
    }
}
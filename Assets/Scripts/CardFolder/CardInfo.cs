using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class CardInfo : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isSupporterCard;
    public int cardNumber;
    public string cardName;
    public int damage;
    public int cardCooldown;
    public string cardDetail;
    //Damage_Range;

    public CardManager cardMgr;

    public bool isMoveCard;
    public bool isSelected = false;

    public GameObject cardObj;
    public GameObject cardOrder;

    public GameObject cardOrderImg;
    public GameObject cardOrderImg2;    //움직임 카드 큐에 2개 이상 추가할 경우 사용할 오브젝트
    public GameObject cardOrderImg3;

    //이동 카드를 클릭할 경우 해당 버튼을 통해 이동 버튼을 큐에 삽입 및 삭제합니다.
    public GameObject cardPlusBTNPrefab;
    public GameObject cardMinusBTNPrefab;
    public GameObject plusCardBTN;
    public GameObject minusCardBTN;

    public SpriteRenderer cardOrderSpriter;
    public List<GameObject> order;
    
    //엄지민 추가
    bool isClicked = false; //클릭판정
    private float ClickedTime = 0;
    private float MaxClickTime = 1; //롱클릭 판정
    private void Start()
    {
        if (cardMgr != null)
            order = cardMgr.cardQueue;
        else
        {
            cardMgr = CardManager.cardManager;
            order = cardMgr.cardQueue;
        }

        InstantiateCardImg();
    }

    void InstantiateCardImg()
    {
        cardOrderImg = Instantiate(cardOrder, transform); // 카드 오른쪽 상단에 image 생성 후 안보이게 함.

        if (this.isMoveCard)
        {
            cardOrderImg2 = Instantiate(cardOrder, transform); // 카드 오른쪽 상단에 image 생성 후 안보이게 함.
            cardOrderImg3 = Instantiate(cardOrder, transform); // 카드 오른쪽 상단에 image 생성 후 안보이게 함.
        }

        Vector2 position = new Vector2(60, 60);
        cardOrderImg.transform.localPosition = position;
        cardOrderImg.SetActive(false);
        cardOrderSpriter = cardOrderImg.GetComponent<SpriteRenderer>();

        if (this.isMoveCard)
        {
            Vector2 position2 = new Vector2(60, 30);
            cardOrderImg2.transform.localPosition = position2;
            cardOrderImg2.SetActive(false);

            Vector2 position3 = new Vector2(60, 0);
            cardOrderImg3.transform.localPosition = position3;
            cardOrderImg3.SetActive(false);
        }
    }
    public void OnPointerDown (PointerEventData Data)
    {
        isClicked = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
        ClickedTime = 0;
    }
    private void Update()
    {
        if(isClicked)
        {
            ClickedTime += Time.deltaTime;
            Debug.Log(ClickedTime);
        }
        if(ClickedTime >= MaxClickTime)
        {
            cardMgr.longClick(cardObj);
        }
        
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
            if (order.Count >= 3) return; // 카드가 세 개 선택 된 경우 동작하지 않음.
            // 큐의 마지막 인덱스 번호 = 카드 번호. 해당 번호의 이미지 불러옴.
            cardOrderImg.GetComponent<Image>().sprite = cardMgr.sprites[order.Count];
            cardOrderImg.SetActive(true);// 이미지 나타나게 함.
            order.Add(cardObj); // 해당 카드 번호 큐에 삽입
            isSelected = true;
        }
    }

    //MoveCard를 선택해 카드를 추가할 것인지, 제거할 것인지 선택하는 버튼을 화면에 출력합니다.
    public void SelectMoveCard()
    {
        if (cardMgr.isBTNOpened == false)
        {
            //order.count == 0 일때 +버튼만 출력
            if (order.Count == 0)
            {
                //클릭하면 좌우에 버튼 생성
                plusCardBTN = Instantiate(cardPlusBTNPrefab, transform);

                Vector2 plusPos = new Vector2(90, 30);
                plusCardBTN.transform.localPosition = plusPos;
                plusCardBTN.SetActive(true);

                cardMgr.isBTNOpened = true;
            }
            //order.count == 3 일때 -버튼만 출력
            else if (order.Count == 3)
            {
                //클릭하면 좌우에 버튼 생성
                minusCardBTN = Instantiate(cardMinusBTNPrefab, transform);

                Vector2 minusPos = new Vector2(-90, 30);
                minusCardBTN.transform.localPosition = minusPos;
                minusCardBTN.SetActive(true);

                cardMgr.isBTNOpened = true;
            }
            else
            {
                //클릭하면 좌우에 버튼 생성
                plusCardBTN = Instantiate(cardPlusBTNPrefab, transform);
                minusCardBTN = Instantiate(cardMinusBTNPrefab, transform);

                Vector2 plusPos = new Vector2(90, 30);
                plusCardBTN.transform.localPosition = plusPos;
                plusCardBTN.SetActive(true);

                Vector2 minusPos = new Vector2(-90, 30);
                minusCardBTN.transform.localPosition = minusPos;
                minusCardBTN.SetActive(true);

                cardMgr.isBTNOpened = true;
            }
        }
        //버튼이 열려있을 경우 버튼 제거
        else if (cardMgr.isBTNOpened == true)
        {
            //order.count == 0 일때 +버튼만 삭제
            if (order.Count == 0 && plusCardBTN.activeSelf == true)
            {
                Destroy(plusCardBTN);
                cardMgr.isBTNOpened = false;
            }
            //order.count == 3 일때 -버튼만 삭제
            else if (order.Count == 3 && minusCardBTN.activeSelf == true)
            {
                Destroy(minusCardBTN);
                cardMgr.isBTNOpened = false;
            }
            else
            {
                Destroy(plusCardBTN);
                Destroy(minusCardBTN);
                cardMgr.isBTNOpened = false;
            }
        }
        else Debug.Log("CardInfo Func error");
    }

    public void ReOrder()
    {
        cardOrderImg.GetComponent<Image>().sprite = cardMgr.sprites[order.IndexOf(cardObj)]; // 큐에서 자기 인덱스 번호의 이미지로 변경.
    }

}
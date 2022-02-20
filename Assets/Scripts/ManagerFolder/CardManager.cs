using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class CardManager : MonoBehaviour
{
    public static CardManager cardManager;
    public GameManager gameManager;
    public CharacterManager charManager;

    public List<GameObject> cardQueue;  //스킬 및 이동카드 3개 저장용도 입니다.
    public Sprite[] sprites;            //카드 순서를 표현해줄 이미지를 받아옵니다.

    public GameObject scrollContent;        //카드를 뿌릴 스크롤 바의 Content 객체
    public List<GameObject> gilbertCards;   //instantiate하기 전용 프리팹 리스트
    public List<GameObject> walwhaCards;
    public List<GameObject> patrickCards;
    public bool isBTNOpened = false;        //CardInfo, CardBTN에서 이동카드를 추가하는 버튼이 열려있는지 확인하는 변수

    public GameObject firstCard;
    public GameObject secondCard;
    public GameObject thirdCard;

    GameObject saveCard;    //플레이어가 선택한 카드를 Instantiate할 때 잠깐 담는 변수
    CardInfo saveCardInfo;  //Instantiate한 카드의 스크립트 정보를 받아올 때 사용할 변수
    public List<GameObject> saveCards;

    bool isFirstCardPrint = false;
    bool isSecondCardPrint = false;
    bool isThirdCardPrint = false;

    //220216/정윤석/카드 프리팹 변경 이후 사용할 변수들
    

    void Awake()
    {
        //매니저가 존재하지 않으면 현재 오브젝트를 싱글톤으로 생성합니다.
        if (cardManager == null)
        {
            cardManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        charManager = CharacterManager.charManager;
        sprites = Resources.LoadAll<Sprite>("CardOrder"); //Resources 폴더의 Sprites/Cardorder 의 이미지 불러서 배열에 저장.
        InstantiageCards();
    }

    public void ChangeOrderImg() // 모든 큐에 대해 이미지 다시 불러옴.
    {
        for (int i = 0; i < cardQueue.Count; i++)
        {
            cardQueue[i].GetComponent<CardInfo>().ReOrder();
        }
    }

    void InstantiageCards()
    {
        GameObject cards;

        int strikerIdx = (int)charManager.strikerName;

        //스트라이커 카드 Instantiate
        switch (strikerIdx)
        {
            case 0 :
                for (int i = 0; i < gilbertCards.Count; i++)
                {
                    cards = Instantiate(gilbertCards[i], transform.position, Quaternion.identity);
                    cards.transform.SetParent(scrollContent.transform);

                    if (i < 4)
                        cards.transform.localPosition = new Vector3(200 + (270 * i), -200, 0);
                    else if (i >= 4 && i < 8)
                        cards.transform.localPosition = new Vector3(200 + (270 * (i - 4)), -450, 0);
                    else
                        cards.transform.localPosition = new Vector3(200 + (270 * (i - 8)), -700, 0);
                }
                for (int i = 0; i < 4; i++)
                {
                    cards = Instantiate(walwhaCards[i + 4], transform.position, Quaternion.identity);
                    cards.transform.SetParent(scrollContent.transform);
                    cards.transform.localPosition = new Vector3(200 + (270 * i), -1050, 0);
                }
                for (int i = 0; i < 4; i++)
                {
                    cards = Instantiate(patrickCards[i + 4], transform.position, Quaternion.identity);
                    cards.transform.SetParent(scrollContent.transform);
                    cards.transform.localPosition = new Vector3(200 + (270 * i), -1300, 0);
                }
                break;
            case 1:
                for (int i = 0; i < walwhaCards.Count; i++)
                {
                    cards = Instantiate(walwhaCards[i], transform.position, Quaternion.identity);
                    cards.transform.SetParent(scrollContent.transform);

                    if (i < 4)
                        cards.transform.localPosition = new Vector3(200 + (270 * i), -200, 0);
                    else if (i >= 4 && i < 8)
                        cards.transform.localPosition = new Vector3(200 + (270 * (i - 4)), -450, 0);
                    else
                        cards.transform.localPosition = new Vector3(200 + (270 * (i - 8)), -700, 0);
                }
                for (int i = 0; i < 4; i++)
                {
                    cards = Instantiate(patrickCards[i + 4], transform.position, Quaternion.identity);
                    cards.transform.SetParent(scrollContent.transform);
                    cards.transform.localPosition = new Vector3(200 + (270 * i), -1050, 0);
                }
                for (int i = 0; i < 4; i++)
                {
                    cards = Instantiate(gilbertCards[i + 4], transform.position, Quaternion.identity);
                    cards.transform.SetParent(scrollContent.transform);
                    cards.transform.localPosition = new Vector3(200 + (270 * i), -1300, 0);
                }
                break;
            case 2:
                for (int i = 0; i < patrickCards.Count; i++)
                {
                    cards = Instantiate(patrickCards[i], transform.position, Quaternion.identity);
                    cards.transform.SetParent(scrollContent.transform);

                    if (i < 4)
                        cards.transform.localPosition = new Vector3(200 + (270 * i), -200, 0);
                    else if (i >= 4 && i < 8)
                        cards.transform.localPosition = new Vector3(200 + (270 * (i - 4)), -450, 0);
                    else
                        cards.transform.localPosition = new Vector3(200 + (270 * (i - 8)), -700, 0);
                }
                for (int i = 0; i < 4; i++)
                {
                    cards = Instantiate(walwhaCards[i + 4], transform.position, Quaternion.identity);
                    cards.transform.SetParent(scrollContent.transform);
                    cards.transform.localPosition = new Vector3(200 + (270 * i), -1050, 0);
                }
                for (int i = 0; i < 4; i++)
                {
                    cards = Instantiate(gilbertCards[i + 4], transform.position, Quaternion.identity);
                    cards.transform.SetParent(scrollContent.transform);
                    cards.transform.localPosition = new Vector3(200 + (270 * i), -1300, 0);
                }
                break;
        }
    }

    //cardQueue에 있는 카드들을 SelectCard 우측에 표시하는 함수.
    public void SetSelectedCard()
    {
        /// 1. 카드를 선택해 큐에 추가되면 순서에 맞는 위치를 찾아 해당 위치에 출력한다.
        if (cardQueue.Count > 3) return;
        
        switch (cardQueue.Count)
        {
            case 1:
                if (!isFirstCardPrint)
                {
                    saveCard = Instantiate(cardQueue[0], transform);
                    saveCard.transform.SetParent(firstCard.transform);
                    saveCard.transform.localPosition = new Vector3(0, 0, 0);

                    //해당 카드 버튼 능력 제거 + 순서 이미지 전부 setActive(false)
                    saveCard.GetComponent<Button>().interactable = false;
                    saveCardInfo = saveCard.GetComponent<CardInfo>();
                    saveCardInfo.cardOrderImg.SetActive(false);
                    if (saveCardInfo.isMoveCard)
                    {
                        saveCardInfo.cardOrderImg2.SetActive(false);
                        saveCardInfo.cardOrderImg3.SetActive(false);
                    }

                    saveCards.Add(saveCard);

                    isFirstCardPrint = true;
                }
                break;
            case 2:
                if (!isSecondCardPrint)
                {
                    saveCard = Instantiate(cardQueue[1], transform);
                    saveCard.transform.SetParent(secondCard.transform);
                    saveCard.transform.localPosition = new Vector3(0, 0, 0);

                    //해당 카드 버튼 능력 제거 + 순서 이미지 전부 setActive(false)
                    saveCard.GetComponent<Button>().interactable = false;
                    saveCardInfo = saveCard.GetComponent<CardInfo>();
                    saveCardInfo.cardOrderImg.SetActive(false);
                    if (saveCardInfo.isMoveCard)
                    {
                        saveCardInfo.cardOrderImg2.SetActive(false);
                        saveCardInfo.cardOrderImg3.SetActive(false);
                    }

                    saveCards.Add(saveCard);

                    isSecondCardPrint = true;
                }
                break;
            case 3:
                if (!isThirdCardPrint)
                {
                    saveCard = Instantiate(cardQueue[2], transform);
                    saveCard.transform.SetParent(thirdCard.transform);
                    saveCard.transform.localPosition = new Vector3(0, 0, 0);

                    //해당 카드 버튼 능력 제거 + 순서 이미지 전부 setActive(false)
                    saveCard.GetComponent<Button>().interactable = false;
                    saveCardInfo = saveCard.GetComponent<CardInfo>();
                    saveCardInfo.cardOrderImg.SetActive(false);
                    if (saveCardInfo.isMoveCard)
                    {
                        saveCardInfo.cardOrderImg2.SetActive(false);
                        saveCardInfo.cardOrderImg3.SetActive(false);
                    }

                    saveCards.Add(saveCard);

                    isThirdCardPrint = true;
                }
                break;
        }
    }

    //cardQueue에서 카드가 삭제되면 SelectCard 우측에서도 삭제하는 함수.
    public void DeleteSelectedCard()
    {
        GameObject temp;
        int deletedIdx = DeletedCardIdx();

        ///1. 삭제하는 카드가 첫 번째 카드일 때
        if (deletedIdx == 0)
        {
            //2,3번째 카드가 없을 경우 해당 카드만 삭제.
            if (!isSecondCardPrint && !isThirdCardPrint)
            {
                temp = saveCards[0];
                saveCards.RemoveAt(0);
                Destroy(temp);

                isFirstCardPrint = false;
            }

            else if(isSecondCardPrint && !isThirdCardPrint)
            {
                temp = saveCards[0];
                saveCards.RemoveAt(0);
                Destroy(temp);

                saveCards[0].transform.SetParent(firstCard.transform);
                saveCards[0].transform.localPosition = new Vector3(0, 0, 0);
                isSecondCardPrint = false;
            }

            else if(isSecondCardPrint && isThirdCardPrint)
            {
                temp = saveCards[0];
                saveCards.RemoveAt(0);
                Destroy(temp);

                saveCards[0].transform.SetParent(firstCard.transform);
                saveCards[0].transform.localPosition = new Vector3(0, 0, 0);

                saveCards[1].transform.SetParent(secondCard.transform);
                saveCards[1].transform.localPosition = new Vector3(0, 0, 0);

                isThirdCardPrint = false;
            }
        }
        ///2. 삭제하는 카드가 두 번째 카드일 때
        else if (deletedIdx == 1)
        {
            if (!isThirdCardPrint)
            {
                temp = saveCards[1];
                saveCards.RemoveAt(1);
                Destroy(temp);

                isSecondCardPrint = false;
            }
            else
            {
                temp = saveCards[1];
                saveCards.RemoveAt(1);
                Destroy(temp);

                saveCards[1].transform.SetParent(secondCard.transform);
                saveCards[1].transform.localPosition = new Vector3(0, 0, 0);
                isThirdCardPrint = false;
            }

        }
        ///4. 삭제하는 카드가 세 번째 카드일 때
        else if (deletedIdx == 2)
        {
            temp = saveCards[2];
            saveCards.RemoveAt(2);
            Destroy(temp);

            isThirdCardPrint = false;
        }

        else Debug.Log("CardManager.DeleteSelectedCard() error!");
    }

    //cardQueue에서 삭제된 오브젝트의 index를 찾습니다.
    int DeletedCardIdx()
    {
        StringBuilder objNameBulider = new StringBuilder();

        for (int i=0; i<saveCards.Count; i++)
        {
            if (cardQueue.Count == i) return i;

            objNameBulider.Append(cardQueue[i].name);
            objNameBulider.Append("(Clone)");
            
            if (saveCards[i].name != objNameBulider.ToString())
                return i;
            
            objNameBulider.Clear();
        }
        return -1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] CardInfo cardData; //아직 미사용
    public List<GameObject> cardQueue;  //스킬 및 이동카드 3개 저장용도 입니다.
    public static CardManager cardManager;
    public GameManager gameManager;
    public CharacterManager charManager;

    public Sprite[] sprites;            //카드 순서를 표현해줄 이미지를 받아옵니다.

    public GameObject scrollContent;        //카드를 뿌릴 스크롤 바의 Content 객체
    public List<GameObject> gilbertCards;   //instantiate하기 전용 프리팹 리스트
    public List<GameObject> walwhaCards;
    public List<GameObject> patrickCards;
    public bool isBTNOpened = false;        //CardInfo, CardBTN에서 이동카드를 추가하는 버튼이 열려있는지 확인하는 변수

    void Awake()
    {
        //매니저가 존재하지 않으면 현재 오브젝트를 싱글톤으로 생성합니다.
        if (cardManager == null)
        {
            cardManager = this;
            sprites = Resources.LoadAll<Sprite>("CardOrder"); //Resources 폴더의 Sprites/Cardorder 의 이미지 불러서 배열에 저장.
            DontDestroyOnLoad(gameObject);

            InstantiageCards();
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
            cardQueue[i].GetComponent<CardInfo>().ReOrder();
        }
    }

    void InstantiageCards()
    {
        GameObject cards;
        int striker = charManager.strikerCharPrefab.GetComponent<Character>().Character_ID;
        //스트라이커 카드 Instantiate
        if(striker == 0)
        {
            for (int i=0; i<gilbertCards.Count; i++)
            {
                cards = Instantiate(gilbertCards[i], transform.position, Quaternion.identity);
                cards.transform.parent = scrollContent.transform;

                if(i<4)
                    cards.transform.localPosition = new Vector3(200 +(270 *i),-200,0);
                else if(i>=4&&i<8)
                    cards.transform.localPosition = new Vector3(200 + (270 * (i-4)), -450, 0);
                else
                    cards.transform.localPosition = new Vector3(200 + (270 * (i-8)), -700, 0);
            }
            for(int i=0; i<4; i++)
            {
                cards = Instantiate(walwhaCards[i+4], transform.position, Quaternion.identity);
                cards.transform.parent = scrollContent.transform;
                cards.transform.localPosition = new Vector3(200 +(270*i), -1050, 0);
            }
            for(int i=0; i<4; i++)
            {
                cards = Instantiate(patrickCards[i+4], transform.position, Quaternion.identity);
                cards.transform.parent = scrollContent.transform;
                cards.transform.localPosition = new Vector3(200 +(270*i), -1300, 0);
            }
        }

        if(striker == 1)
        {
            for (int i=0; i<walwhaCards.Count; i++)
            {
                cards = Instantiate(walwhaCards[i], transform.position, Quaternion.identity);
                cards.transform.parent = scrollContent.transform;

                if(i<4)
                    cards.transform.localPosition = new Vector3(200 +(270 *i),-200,0);
                else if(i>=4&&i<8)
                    cards.transform.localPosition = new Vector3(200 + (270 * (i-4)), -450, 0);
                else
                    cards.transform.localPosition = new Vector3(200 + (270 * (i-8)), -700, 0);
            }
            for(int i=0; i<4; i++)
            {
                cards = Instantiate(patrickCards[i+4], transform.position, Quaternion.identity);
                cards.transform.parent = scrollContent.transform;
                cards.transform.localPosition = new Vector3(200 +(270*i), -1050, 0);
            }
            for(int i=0; i<4; i++)
            {
                cards = Instantiate(gilbertCards[i+4], transform.position, Quaternion.identity);
                cards.transform.parent = scrollContent.transform;
                cards.transform.localPosition = new Vector3(200 +(270*i), -1300, 0);
            }
        }

        if(striker == 2)
        {
            for (int i=0; i<patrickCards.Count; i++)
            {
                cards = Instantiate(patrickCards[i], transform.position, Quaternion.identity);
                cards.transform.parent = scrollContent.transform;

                if(i<4)
                    cards.transform.localPosition = new Vector3(200 +(270 *i),-200,0);
                else if(i>=4&&i<8)
                    cards.transform.localPosition = new Vector3(200 + (270 * (i-4)), -450, 0);
                else
                    cards.transform.localPosition = new Vector3(200 + (270 * (i-8)), -700, 0);
            }
            for(int i=0; i<4; i++)
            {
                cards = Instantiate(walwhaCards[i+4], transform.position, Quaternion.identity);
                cards.transform.parent = scrollContent.transform;
                cards.transform.localPosition = new Vector3(200 +(270*i), -1050, 0);
            }
            for(int i=0; i<4; i++)
            {
                cards = Instantiate(gilbertCards[i+4], transform.position, Quaternion.identity);
                cards.transform.parent = scrollContent.transform;
                cards.transform.localPosition = new Vector3(200 +(270*i), -1300, 0);
            }
        }

    }
}

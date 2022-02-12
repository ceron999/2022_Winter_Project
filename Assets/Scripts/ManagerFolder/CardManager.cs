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
            //막힘... Striker(Support)SkillBTN+cardQueue[i].Reorder() 이런식으로 해야되는데... 어케함?
            cardQueue[i].GetComponent<CardInfo>().ReOrder();
        }
    }

    void InstantiageCards()
    {
        GameObject cards;
        //스트라이커 카드 Instantiate
        for (int i=0; i<gilbertCards.Count; i++)
        {
            cards = Instantiate(gilbertCards[i], transform.position, Quaternion.identity);
            cards.GetComponent<CardInfo>().cardMgr = cardManager;
            cards.transform.parent = scrollContent.transform;

            if(i<4)
                cards.transform.localPosition = new Vector3(200 +(270 *i),-200,0);
            else if(i>=4&&i<8)
                cards.transform.localPosition = new Vector3(200 + (270 * (i-4)), -450, 0);
            else
                cards.transform.localPosition = new Vector3(200 + (270 * (i-8)), -700, 0);
        }
    }
}

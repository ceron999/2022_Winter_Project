using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] tempCardData cardData;
    public List<int> cardQueue;
    public static CardManager cardManager;
<<<<<<< Updated upstream
    public Sprite[] sprites;
    public GameObject StrikerSkillBTN;
    void Start()
=======
    public GameManager gameManager;
    public CharacterManager charManager;
    public Sprite[] sprites;            //카드 순서를 표현해줄 이미지를 받아옵니다.
    public GameObject scrollContent;        //카드를 뿌릴 스크롤 바의 Content 객체
    public List<GameObject> gilbertCards;   //instantiate하기 전용 프리팹 리스트
    public bool isBTNOpened = false;        //CardInfo, CardBTN에서 이동카드를 추가하는 버튼이 열려있는지 확인하는 변수

    void Awake()
>>>>>>> Stashed changes
    {
        cardManager = this;
        sprites = Resources.LoadAll<Sprite>("Sprites/CardOrder"); //Resources 폴더의 Sprites/Cardorder 의 이미지 불러서 배열에 저장.
    }

    public void ChangeOrderImg() // 모든 큐에 대해 이미지 다시 불러옴.
    {
        for (int i = 0; i < cardQueue.Count; i++)
        {
            //막힘... Striker(Support)SkillBTN+cardQueue[i].tempCardData.Reorder() 이런식으로 해야되는데... 어케함?
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //오네가이
    public static GameManager gameManager;
    public CardManager cardMgr;

    public CardSkill cardSkill;         //카드 스킬 데이터를 가진 스크립트입니다.
    public List<GameObject> playerCards;
    public List<GameObject> enemyCards;
    public List<GameObject> battleCardOrder;

    //카드 위치
    public GameObject firstCardPos;
    public GameObject secondCardPos;
    public GameObject thirdCardPos;
    public GameObject forthCardPos;
    public GameObject fifthCardPos;
    public GameObject sixthCardPos;

    public GameObject player;
    public Character playerInfo;
    public GameObject enemy;
    public Enemy1 enemy1Info;
    //[SerializeField] Enemy enemy;

    public int Turn = 1;
    public bool isTurnEnd = false;
    public bool isVictory = false;
    public bool isDefeated = false;

    //임시 버튼
    [SerializeField] GameObject gameStartBTN;


    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        cardMgr = CardManager.cardManager;

        playerInfo = player.GetComponent<Character>();
        enemy1Info = enemy.GetComponent<Enemy1>();

        //카드 순서대로 만들기
        SetBattleCardOrder();
        SetCardsOrder();
        InstanciateCards();
    }

    private void Update()
    {
        //if (player.transform.position.y == 0)
        //    cardSkill.Move(108);
    }

    //내가 선택한 카드를 playerCards 리스트에 새로 저장한다.
    void SetBattleCardOrder()
    {
        GameObject card;
        int cardNum;
        int cardidx;

        for (int i=0; i< cardMgr.saveCards.Count; i++)
        {
            cardNum = cardMgr.saveCardsIdx[i];
            
            //길버트
            if (cardNum / 100 == 1)
            {
                cardidx = cardNum % 100;
                card = cardMgr.gilbertCards[cardidx];
                playerCards.Add(card);
            }

            //월화
            else if (cardNum / 100 == 2)
            {
                cardidx = cardNum % 100;
                card = cardMgr.walwhaCards[cardidx];
                playerCards.Add(card);
            }

            //패트릭
            else if (cardNum / 100 == 3)
            {
                cardidx = cardNum % 100;
                card = cardMgr.patrickCards[cardidx];
                playerCards.Add(card);
            }

            else Debug.Log("GameManager.SetBattleCardOrder error");
        }
    }

    //적과 내 카드의 스피드를 계산해 카드 순서를 설정한다. 
    void SetCardsOrder() // 플레이어 1차이 = 에너미 2차이 => 플레이어에 가중치 1 부여 후 계산
    {
        List<GameObject> big = new List<GameObject>(3);
        List<GameObject> small = new List<GameObject>(3);

        int gap = playerInfo.Speed + 1 - enemy1Info.Speed; // player에 가중치 1 더함.
        
        if (gap > 0)
        {
            for (int i = 0; i < 3; i++)
            {
                big.Add(playerCards[i]);
                small.Add(enemyCards[i]);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                big.Add(enemyCards[i]);
                small.Add(playerCards[i]);
            }
        }


        if (gap == 1) // BSBSBS
        {
            for (int i = 0; i < 3; i++)
            {
                battleCardOrder.Add(big[i]);
                battleCardOrder.Add(small[i]);
            }
        }
        else if (gap == 2) // BBSBSS  BBBSSS 하고 가운데 바꿈
        {
            for (int i = 0; i < 3; i++) battleCardOrder.Add(big[i]);
            for (int i = 0; i < 3; i++) battleCardOrder.Add(small[i]);
            GameObject tmp = battleCardOrder[2];
            battleCardOrder[2] = battleCardOrder[3];
            battleCardOrder[3] = tmp;
        }
        else //BBBSSS
        {
            for (int i = 0; i < 3; i++) battleCardOrder.Add(big[i]);
            for (int i = 0; i < 3; i++) battleCardOrder.Add(small[i]);
        }
    }

    //battleCardOrder의 순서대로 화면에 추력하는 함수
    public void InstanciateCards()
    {
        GameObject card;
        for (int i = 0; i < 6; i++) // 카드 생성 후 위치에 맞게 넣음
        {
            card = Instantiate(battleCardOrder[i], transform.position, Quaternion.identity);

            switch (i)
            {
                case 0:
                    card.transform.SetParent(firstCardPos.transform);
                    card.transform.localPosition = new Vector3(0,0,0);
                    break;
                case 1:
                    card.transform.SetParent(secondCardPos.transform);
                    card.transform.localPosition = new Vector3(0, 0, 0);
                    break;
                case 2:
                    card.transform.SetParent(thirdCardPos.transform);
                    card.transform.localPosition = new Vector3(0, 0, 0);
                    break;
                case 3:
                    card.transform.SetParent(forthCardPos.transform);
                    card.transform.localPosition = new Vector3(0, 0, 0);
                    break;
                case 4:
                    card.transform.SetParent(fifthCardPos.transform);
                    card.transform.localPosition = new Vector3(0, 0, 0);
                    break;
                case 5:
                    card.transform.SetParent(sixthCardPos.transform);
                    card.transform.localPosition = new Vector3(0, 0, 0);
                    break;
            }
        }
    }
}

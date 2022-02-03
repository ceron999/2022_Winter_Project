using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterMgr : MonoBehaviour
{
    [SerializeField] Text cardExplanation;
    [SerializeField] GameObject Gameobj;
    public Camera cam;
    public RaycastHit2D hit;
    public List<CardEx> cardList;

    void Start()
    {
        for (int i = 0; i < cardList.Count;i++)
        {
            /*prefab시 position 조정
            PlayerCard[i]의 position의 위치로 instantiate하는 구문 들어가야함
            캐릭터가 셋이고 추가할 의향 없으면 하드코딩(캐릭터 카드 스크립트 세 개 만들기) 해도 됨
            */
            /*카드 정보 받아옴*/
        }

    }

    // Update is called once per frame
    void Update()
    {
        //클릭 시 발생
        if(Input.GetMouseButtonDown(0))
        {
            //클릭 한 부분에서 ray를 쏨. ray가 물체에 닿아서 그 object가 card면 동작 수행
            Vector2 mousePos = cam.ScreenToViewportPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if(hit.collider != null)
            {
                GameObject clickedObj = hit.collider.gameObject;
                if(clickedObj.tag == "Card")
                {
                    CardEx clickedCard = hit.collider.gameObject.GetComponent<CardEx>();
                    HighlightCard(clickedCard);
                    cardExplanation.text = clickedCard.Explanation.ToString();
                    // cardExplanation = clickedCard.Explanation;
                }
            }
        }
    }

    void HighlightCard(CardEx card)
    {
        for (int i = 0; i < 3;i++)
        {
            if(cardList[i] == card)
            {
                card.GetComponent<SpriteRenderer>().color = Color.red;
                continue;
            }
            cardList[i].GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }

}

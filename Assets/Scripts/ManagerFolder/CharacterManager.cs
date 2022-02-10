using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    static public CharacterManager charManager;
    public GameManager gameManager;

    //캐릭터들 스크립트를 가져올 수 있는 obj List
    public List<GameObject> charList = new List<GameObject>();
    public GameObject StrikerCharacter;     //현재 스트라이커로 지정된 오브젝트입니다.
    public GameObject highlightedChar = null;    //현재 강조된 캐릭터 obj를 담습니다.

    //UI클릭을 위한 재료들
    [SerializeField] GameObject canvas;
    GraphicRaycaster gRay;
    PointerEventData pointerEventData;
    EventSystem eventSystem;

    //text관련 출력을 위한 text모음들
    public Text charDetailText;
    public Text characteristicText;

    private void Awake()
    {
        charManager = this;
        gRay = canvas.GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
    }

    private void Start()
    {
        GameObject strikertext = StrikerCharacter.transform.Find("RoleText").gameObject;
        strikertext.GetComponent<Text>().text = "Striker";
    }

    private void Update()
    {
#if UNITY_EDITOR_WIN
        if (Input.GetMouseButtonDown(0))
        {
            Click2Mouse();
        }
#elif UNITY_ANDROID
        if(Input.touchCount>0)
        {
            Click2Android();
        }
#endif

    }

    /// <summary>
    /// pc버전
    /// 마우스로 해당 캐릭터를 클릭할 경우 해당 캐릭터가 강조되고 관련 데이터를 화면에 출력합니다.
    /// </summary>
    void Click2Mouse()
    {
        //이벤트 시스템을 pointerEventData에 집어넣음
        pointerEventData = new PointerEventData(eventSystem);
        //마우스포지션을 pointerEventData 포지션에 집어넣음
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        gRay.Raycast(pointerEventData, results);


        GameObject clickCard = results[0].gameObject;
        if (clickCard.CompareTag("CharCard"))
        {
            //화면에 캐릭 정보 출력
            PrintCharText(clickCard);

            //클릭한 캐릭터 강조
            HighlightCharacter(clickCard);
        }
    }


    /// <summary>
    /// 안드로이드 버전
    /// 마우스로 해당 캐릭터를 클릭할 경우 해당 캐릭터가 강조되고 관련 데이터를 화면에 출력합니다.
    /// </summary>
    void Click2Android()
    {
        //이벤트 시스템을 pointerEventData에 집어넣음
        pointerEventData = new PointerEventData(eventSystem);
        //마우스포지션을 pointerEventData 포지션에 집어넣음
        pointerEventData.position = Input.GetTouch(0).position;

        List<RaycastResult> results = new List<RaycastResult>();

        gRay.Raycast(pointerEventData, results);

        if (results != null)
        {
            GameObject clickCard = results[0].gameObject;
            if (clickCard.CompareTag("CharCard"))
            {
                //화면에 캐릭 정보 출력
                PrintCharText(clickCard);

                //클릭한 캐릭터 강조
                HighlightCharacter(clickCard);
            }
        }
    }


    /// <summary>
    /// 공통
    /// click함수를 통해 받은 캐릭터 오브젝트에서 데이터를 뽑아 화면에 출력합니다.
    /// </summary>
    /// <param name="getObj"></param>
    void PrintCharText(GameObject getObj)
    {
        Character getObjInfo = getObj.GetComponent<Character>();

        charDetailText.text = StrikerCharacter.GetComponent<Character>().Character_Detail;

        if (!highlightedChar)
        {
            characteristicText.text = getObjInfo.Characteristic;
        }
        else
        {
            characteristicText.text = null;
        }
    }

    //click함수를 통해 받은 캐릭터를 강조합니다.
    void HighlightCharacter(GameObject getObj)
    {
        //클릭한 obj의 이미지 변수들을 받아옵니다.
        Image getObjIMG = getObj.GetComponent<Image>();

        //선택한 이미지의 색을 강조하거나 취소합니다.
        /*
        if (getObjIMG.color != Color.yellow)
            getObjIMG.color = Color.yellow;
        else
            getObjIMG.color = new Color(143f / 255f, 170f / 255f, 220f / 255f);
        */

        Vector3 getposition = getObj.transform.position;

        if (!highlightedChar)
        {
            //해당 캐릭터를 강조
            getObjIMG.color = Color.yellow;
            highlightedChar = getObj;
        }

        else if (getObj == highlightedChar)
        {
            //1. 클릭한 객체와 하이라이트 캐릭터가 동일할 경우
            //클릭한 캐릭터의 색을 원래대로 되돌립니다.
            getObjIMG.color = new Color(143f / 255f, 170f / 255f, 220f / 255f);
            highlightedChar = null;
        }

        else if (getObj != highlightedChar)
        {
            //2. 클릭한 객체와 하이라이트 캐릭터가 다를 경우
            //클릭한 캐릭터를 강조하고 기존 캐릭터를 원상태로 복구시킵니다.
            Image highlightedCharIMG;   //현재 강조된 캐릭터 이미지 변수들
            highlightedCharIMG = highlightedChar.GetComponent<Image>();

            //getObjIMG.color = Color.yellow;
            highlightedCharIMG.color = new Color(143f / 255f, 170f / 255f, 220f / 255f);

            //클릭한 객체가 스트라이커인 경우
            if(getObj==StrikerCharacter)
            {
                StrikerCharacter = highlightedChar;

                StrikerCharacter.GetComponent<Character>().isStriker = true;
                StrikerCharacter.GetComponent<Character>().isSupporter = false;
                StrikerCharacter.transform.Find("RoleText").GetComponent<Text>().text = "Striker";

                getObj.GetComponent<Character>().isStriker = false;
                getObj.GetComponent<Character>().isSupporter = true;
                getObj.transform.Find("RoleText").GetComponent<Text>().text = "Supporter";
            }

            //하이라이트 캐릭터가 스트라이커인 경우
            else if(highlightedChar==StrikerCharacter)
            {
                StrikerCharacter = getObj;

                StrikerCharacter.GetComponent<Character>().isStriker = true;
                StrikerCharacter.GetComponent<Character>().isSupporter = false;
                StrikerCharacter.transform.Find("RoleText").GetComponent<Text>().text = "Striker";

                highlightedChar.GetComponent<Character>().isStriker = false;
                highlightedChar.GetComponent<Character>().isSupporter = true;
                highlightedChar.transform.Find("RoleText").GetComponent<Text>().text = "Supporter";

            }
            
            //위치 바꾸기
            getObj.transform.position = highlightedChar.transform.position;
            highlightedChar.transform.position = getposition;

            //위치 바뀐 후의 스트라이커 캐릭터 특성 설명
            charDetailText.text = StrikerCharacter.GetComponent<Character>().Character_Detail;

            //highlightedChar = getObj;
            highlightedChar = null;
        }
        else
        {
            //예외처리
            Debug.LogError("캐릭터 강조 함수 오류");
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    static public CharacterManager charManager;
    public GameManager gameManager;

    public enum CharacterName
    {
        Gilbert,Walhwa,Patrick
    }

    //캐릭터들 스크립트를 가져올 수 있는 obj List
    public List<GameObject> charList = new List<GameObject>();

    public CharacterName strikerName;
    public GameObject strikerCharPrefab;
    public GameObject StrikerCharacter;     //현재 스트라이커로 지정된 오브젝트입니다.
    public GameObject highlightedChar = null;    //현재 강조된 캐릭터 obj를 담습니다.

    //UI클릭을 위한 재료들
    [SerializeField] GameObject canvas;
    public GraphicRaycaster gRay;
    PointerEventData pointerEventData;
    EventSystem eventSystem;

    //text관련 출력을 위한 text모음들
    public Text charDetailText;
    public Text characteristicText;

    private void Awake()
    {
        if (charManager == null)
        {
            charManager = this;
            gRay = canvas.GetComponent<GraphicRaycaster>();
            eventSystem = GetComponent<EventSystem>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        GameObject strikertext = StrikerCharacter.transform.Find("RoleText").gameObject;
        strikertext.GetComponent<Text>().text = "Striker";
    }

    private void Update()
    {

    }

    /// <summary>
    /// pc버전
    /// </summary>

    /// <summary>
    /// 안드로이드 버전
    /// </summary>

    /// <summary>
    /// 공통
    /// click함수를 통해 받은 캐릭터 오브젝트에서 데이터를 뽑아 화면에 출력합니다.
    /// </summary>
    /// <param name="getObj"></param>

    public void PrintCharText(GameObject getObj)
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
    public void HighlightCharacter(GameObject getObj)
    {
        //클릭한 obj의 이미지 변수들을 받아옵니다.
        Image getObjIMG = getObj.GetComponent<Image>();

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

            highlightedCharIMG.color = new Color(143f / 255f, 170f / 255f, 220f / 255f);

            //클릭한 객체가 스트라이커인 경우
            if(getObj==StrikerCharacter)
            {
                StrikerCharacter = highlightedChar;

                StrikerCharacter.GetComponent<Character>().isStriker = true;
                StrikerCharacter.GetComponent<Character>().isSupporter = false;
                StrikerCharacter.transform.GetChild(0).GetComponent<Text>().text = "Striker";

                getObj.GetComponent<Character>().isStriker = false;
                getObj.GetComponent<Character>().isSupporter = true;
                getObj.transform.GetChild(0).GetComponent<Text>().text = "Supporter";
            }

            //하이라이트 캐릭터가 스트라이커인 경우
            else if(highlightedChar==StrikerCharacter)
            {
                StrikerCharacter = getObj;

                StrikerCharacter.GetComponent<Character>().isStriker = true;
                StrikerCharacter.GetComponent<Character>().isSupporter = false;
                StrikerCharacter.transform.GetChild(0).GetComponent<Text>().text = "Striker";

                highlightedChar.GetComponent<Character>().isStriker = false;
                highlightedChar.GetComponent<Character>().isSupporter = true;
                highlightedChar.transform.GetChild(0).GetComponent<Text>().text = "Supporter";
            }
            
            //위치 바꾸기
            getObj.transform.position = highlightedChar.transform.position;
            highlightedChar.transform.position = getposition;

            //위치 바뀐 후의 스트라이커 캐릭터 특성 설명
            charDetailText.text = StrikerCharacter.GetComponent<Character>().Character_Detail;

            //스트라이커 프리팹 저장하는 함수입니다.
            SaveStriker();

            highlightedChar = null;
        }
        else
        {
            //예외처리
            Debug.LogError("캐릭터 강조 함수 오류");
        }

    }

    public void SaveStriker()
    {
        if (StrikerCharacter != null)
        {
            for (int i = 0; i < charList.Count; i++)
            {
                if (StrikerCharacter.name == charList[i].name)
                {
                    strikerCharPrefab = charList[i];

                    switch (i)
                    {
                        case 0:
                            strikerName = CharacterName.Gilbert;
                            break;
                        case 1:
                            strikerName = CharacterName.Walhwa;
                            break;
                        case 2:
                            strikerName = CharacterName.Patrick;
                            break;
                    }

                    break;
                }
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    static public CharacterManager charManager;
    public GameManager gameManager;
    public SceneMoveManager sceneMoveManager;

    public enum CharacterName
    {
        Gilbert,Walwha,Patrick
    }

    //캐릭터들 스크립트를 가져올 수 있는 obj List
    public List<GameObject> charList = new List<GameObject>();

    public CharacterName strikerName;       //스트라이커 카드를 해당 변수로 판단합니다.
    public int strikerIdx;
    public GameObject StrikerCharacter;     //현재 스트라이커로 지정된 오브젝트입니다.
    public GameObject highlightedChar = null;    //현재 강조된 캐릭터 obj를 담습니다.

    //UI클릭을 위한 재료들
    [SerializeField] GameObject canvas;

    //text관련 출력을 위한 text모음들
    public Text strikerExplanationText;
    public Text characteristicText;

    Text DragCharText;
    Text TargetCharText;

    public GameObject enemyExplation;
    public Text enemyExplanationText;

    public GameObject enemyImage;
    public Image testImg; //원래 이미지
    public Sprite enemy;//바뀌어질 이미지

    private void Awake()
    {
        if (charManager == null)
        {
            charManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        sceneMoveManager = SceneMoveManager.sceneMoveManager;

        GameObject strikertext = StrikerCharacter.transform.Find("RoleText").gameObject;
        strikertext.GetComponent<Text>().text = "Striker";

        //적에 대한 설명
        enemyExplanationText.text = enemyExplation.GetComponent<Enemy1>().enemyDetail;
        //적 이미지
        enemy = enemyImage.GetComponent<Enemy1>().enemyImg;
        testImg.sprite = enemy;
    }

    //매개변수로 제공받은 캐릭터의 세부사항을 아래에 출력합니다.
    public void PrintCharText(GameObject getObj)
    {
        Character getObjInfo = getObj.GetComponent<Character>();

        strikerExplanationText.text = StrikerCharacter.GetComponent<Character>().strikerExplanation;

        if (!highlightedChar)
        {
            strikerExplanationText.text = getObjInfo.strikerExplanation;
            characteristicText.text = getObjInfo.characteristic;
        }
        else
        {
            strikerExplanationText.text = StrikerCharacter.GetComponent<Character>().strikerExplanation;
            characteristicText.text = null;
        }
    }

    //click함수를 통해 받은 캐릭터를 강조합니다.
    public void HighlightCharacter(GameObject getObj)
    {
        //클릭한 obj의 이미지 변수들을 받아옵니다.
        Image getObjIMG = getObj.GetComponent<Image>();

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
            }

            //하이라이트 캐릭터가 스트라이커인 경우
            else if(highlightedChar==StrikerCharacter)
            {
                StrikerCharacter = getObj;
            }
            
            highlightedChar = null;
        }
        else
        {
            //예외처리
            Debug.LogError("캐릭터 강조 함수 오류");
        }

    }

    //캐릭터가 이동했을 경우에 해당 캐릭터를 striker로 바꿔주기 위한 함수
    public void SetStriker(GameObject getDragCharacter, GameObject getTargetCharacter)
    {
        DragCharText = getDragCharacter.GetComponentInChildren<Text>();
        TargetCharText = getTargetCharacter.GetComponentInChildren<Text>();
        
        //드래그하는 캐릭이 스트라이커라면 드래그하는 캐릭를 서포터로, 타겟 캐릭을 스트라이커로 조정합니다.
        if (getDragCharacter.name == StrikerCharacter.name)
        {
            StrikerCharacter = getTargetCharacter;
            DragCharText.text = "Supporter";
            TargetCharText.text = "Striker";
        }

        else if (getTargetCharacter.name == StrikerCharacter.name)
        {
            StrikerCharacter = getDragCharacter;
            TargetCharText.text = "Supporter";
            DragCharText.text = "Striker";
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
                    //현재 스트라이커 이름을 저장합니다.
                    strikerName = (CharacterName)i;
                    strikerIdx = i;
                    break;
                }
            }
        }
    }

}

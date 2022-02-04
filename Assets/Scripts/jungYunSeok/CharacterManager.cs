using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterManager: MonoBehaviour
{
    static public CharacterManager charManager;
    public GameManager gameManager;

    //ĳ���͵� ��ũ��Ʈ�� ������ �� �ִ� obj List
    public List<GameObject> charList = new List<GameObject>();
    GameObject highlightedChar = null;    //���� ������ ĳ���� obj�� ����ϴ�.

    //UIŬ���� ���� ����
    [SerializeField] GameObject canvas; 
    GraphicRaycaster gRay;
    PointerEventData pointerEventData;
    EventSystem eventSystem;

    //text���� ����� ���� text������
    public Text charDetailText;
    public Text characteristicText;

    private void Awake()
    {
        charManager = this;
        gRay = canvas.GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
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
    /// pc����
    /// ���콺�� �ش� ĳ���͸� Ŭ���� ��� �ش� ĳ���Ͱ� �����ǰ� ���� �����͸� ȭ�鿡 ����մϴ�.
    /// </summary>
    void Click2Mouse()
    {
        //�̺�Ʈ �ý����� pointerEventData�� �������
        pointerEventData = new PointerEventData(eventSystem);
        //���콺�������� pointerEventData �����ǿ� �������
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        gRay.Raycast(pointerEventData, results);


        GameObject clickCard = results[0].gameObject;
        if (clickCard.CompareTag("CharCard"))
        {
            Debug.Log(clickCard);
            //ȭ�鿡 ĳ�� ���� ���
            PrintCharText(clickCard);

            //Ŭ���� ĳ���� ����
            HighlightCharacter(clickCard);
        }
    }


    /// <summary>
    /// �ȵ���̵� ����
    /// ���콺�� �ش� ĳ���͸� Ŭ���� ��� �ش� ĳ���Ͱ� �����ǰ� ���� �����͸� ȭ�鿡 ����մϴ�.
    /// </summary>
    void Click2Android()
    {
        //�̺�Ʈ �ý����� pointerEventData�� �������
        pointerEventData = new PointerEventData(eventSystem);
        //���콺�������� pointerEventData �����ǿ� �������
        pointerEventData.position = Input.GetTouch(0).position;

        List<RaycastResult> results = new List<RaycastResult>();

        gRay.Raycast(pointerEventData, results);


        GameObject clickCard = results[0].gameObject;
        if (clickCard.CompareTag("CharCard"))
        {
            //ȭ�鿡 ĳ�� ���� ���
            PrintCharText(clickCard);

            //Ŭ���� ĳ���� ����
            HighlightCharacter(clickCard);
        }
    }


    /// <summary>
    /// ����
    /// click�Լ��� ���� ���� ĳ���� ������Ʈ���� �����͸� �̾� ȭ�鿡 ����մϴ�.
    /// </summary>
    /// <param name="getObj"></param>
    void PrintCharText(GameObject getObj)
    {
        Character getObjInfo = getObj.GetComponent<Character>();
        charDetailText.text = getObjInfo.charInfo.Character_Detail;
        characteristicText.text = getObjInfo.charInfo.Characteristic;
    }

    //click�Լ��� ���� ���� ĳ���͸� �����մϴ�.
    void HighlightCharacter(GameObject getObj)
    {
        //Ŭ���� obj�� �̹��� �������� �޾ƿɴϴ�.
        Image getObjIMG = getObj.GetComponent<Image>();

        //������ �̹����� ���� �����ϰų� ����մϴ�.
        if (getObjIMG.color != Color.yellow)
            getObjIMG.color = Color.yellow;
        else
            getObjIMG.color = new Color(143f/255f,170f/255f,220f/255f);


        if(!highlightedChar)
        {
            //�ش� ĳ���͸� ����
            getObjIMG.color = Color.yellow;
            highlightedChar = getObj;
        }

        else if(getObj == highlightedChar)
        {
            //1. Ŭ���� ��ü�� ���̶���Ʈ ĳ���Ͱ� ������ ���
            //Ŭ���� ĳ������ ���� ������� �ǵ����ϴ�.
            getObjIMG.color = new Color(143f / 255f, 170f / 255f, 220f / 255f);
            highlightedChar = null;
        }

        else if(getObj != highlightedChar)
        {
            Image highlightedCharIMG;   //���� ������ ĳ���� �̹��� ������
            highlightedCharIMG = highlightedChar.GetComponent<Image>();

            getObjIMG.color = Color.yellow;
            highlightedCharIMG.color = new Color(143f / 255f, 170f / 255f, 220f / 255f);

            highlightedChar = getObj;
        }
        else
        {
            //����ó��
            Debug.LogError("ĳ���� ���� �Լ� ����");
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharEventTrigger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public CharacterManager charManager;
    public GameObject itemBeingDragged;
    Vector3 startPosition;
    public GameObject target;
    bool isDrag = false;

    public List<GameObject> charList = new List<GameObject>();

    void Start()
    {
        charManager = CharacterManager.charManager;
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (!isDrag)
        {
            GameObject clickCard = data.pointerClick.gameObject;

            if (clickCard.CompareTag("CharCard"))
            {
                //ȭ�鿡 ĳ�� ���� ���
                charManager.PrintCharText(clickCard);

                //Ŭ���� ĳ���� ����
                charManager.HighlightCharacter(clickCard);
            }
        }
    }

    //�� ��ũ��Ʈ�� ���� ������Ʈ�� ���콺 �巡�׸� �������� �� ȣ��
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
        itemBeingDragged = gameObject;
        startPosition = transform.position;
    }

    //���콺 �巡�� ���� ���� ��� ȣ��
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        
        //����� ������Ʈ target���� ���ϱ�
        if (Vector3.Distance(itemBeingDragged.transform.position, charList[0].transform.position)
            < Vector3.Distance(itemBeingDragged.transform.position, charList[1].transform.position))
        {
            target = charList[0];
        }
        else
            target = charList[1];

    }

    //���콺 �巡�� �ϴ� ���� ������ �� ȣ��
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 getposition = startPosition;

        //���� �巡���� �Ͱ� target �Ÿ��� 100���ϸ� swap
        if (Vector3.Distance(itemBeingDragged.transform.position, target.transform.position) <= 100)
        {
            itemBeingDragged.transform.position = target.transform.position;
            target.transform.position = getposition;

            //��Ʈ����Ŀ ī�� ��ġ�� ���ο� ĳ���� ī�尡 �������Ƿ� �ش� ĳ���͸� ��Ʈ����Ŀ�� �����մϴ�.
            charManager.SetStriker(itemBeingDragged, target);
            charManager.SaveStriker();
        }
        //�ƴϸ� ���� ��ġ��
        else
        {
            transform.position = startPosition;
        }
        isDrag = false;
    }
};


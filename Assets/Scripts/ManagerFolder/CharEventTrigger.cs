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

    public List<GameObject> charList = new List<GameObject>();

    public void OnPointerClick(PointerEventData data)
    {
#if UNITY_EDITOR_WIN
        data.position = Input.mousePosition;
#elif UNITY_ANDROID
        data.position = Input.GetTouch(0).position;
#endif

        List<RaycastResult> results = new List<RaycastResult>();

        charManager.gRay.Raycast(data, results);


        GameObject clickCard = results[0].gameObject;
        if (clickCard.CompareTag("CharCard"))
        {
            //ȭ�鿡 ĳ�� ���� ���
            charManager.PrintCharText(clickCard);

            //Ŭ���� ĳ���� ����
            charManager.HighlightCharacter(clickCard);
        }
    }

    //�� ��ũ��Ʈ�� ���� ������Ʈ�� ���콺 �巡�׸� �������� �� ȣ��
    public void OnBeginDrag(PointerEventData eventData)
    {
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
        }
        //�ƴϸ� ���� ��ġ��
        else
        {
            transform.position = startPosition;
        }

    }
};


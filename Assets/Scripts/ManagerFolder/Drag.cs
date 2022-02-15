using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject itemBeingDragged;
    Vector3 startPosition;
    public GameObject target;

    public List<GameObject> charList = new List<GameObject>();


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


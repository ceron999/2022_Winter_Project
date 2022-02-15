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


    //이 스크립트가 붙은 오브젝트를 마우스 드래그를 시작했을 때 호출
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
    }

    //마우스 드래그 중인 동안 계속 호출
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        
        //가까운 오브젝트 target으로 정하기
        if (Vector3.Distance(itemBeingDragged.transform.position, charList[0].transform.position)
            < Vector3.Distance(itemBeingDragged.transform.position, charList[1].transform.position))
        {
            target = charList[0];
        }
        else
            target = charList[1];

    }

    //마우스 드래그 하는 것을 끝냈을 때 호출
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 getposition = startPosition;

        //현재 드래그한 것과 target 거리가 100이하면 swap
        if (Vector3.Distance(itemBeingDragged.transform.position, target.transform.position) <= 100)
        {
            itemBeingDragged.transform.position = target.transform.position;
            target.transform.position = getposition;
        }
        //아니면 원래 위치로
        else
        {
            transform.position = startPosition;
        }

    }
};


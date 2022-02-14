using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour //, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    /*
    public Transform bearPlace;

    public Vector2 initialPosition;
    public Vector2 mousePosition;

    private float deltaX, deltaY;

    void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch(touch.phase)
            {
                case TouchPhase.Began:
                    if(GetComponent<Collider2D>()==Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;

                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    break;

                case TouchPhase.Ended:
                    if (Mathf.Abs(transform.position.x-bearPlace.position.x)<=0.5f&&
                        Mathf.Abs(transform.position.y-bearPlace.position.y)<=0.5f)
                    {
                        transform.position = new Vector2(bearPlace.position.x, bearPlace.position.y);
                    }
                    else
                    {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    }
                    break;                
            }
        }
    }*/

    /*
    private void OnMouseDown()
    {
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;

    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);

    }

    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - bearPlace.position.x) <= 0.5f &&
    Mathf.Abs(transform.position.y - bearPlace.position.y) <= 0.5f)
        {
            transform.position = new Vector2(bearPlace.position.x, bearPlace.position.y);
        }

        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }

    //이 스크립트가 붙은 오브젝트를 마우스 드래그를 시작했을 때 호출
    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    //마우스 드래그 중인 동안 계속 호출
    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = eventData.position;
     }

    //마우스 드래그 하는 것을 끝냈을 때 호출
    public void OnEndDrag(PointerEventData eventData)
    {

    }

    */
};


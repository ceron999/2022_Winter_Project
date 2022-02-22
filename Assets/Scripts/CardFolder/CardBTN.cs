using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBTN : MonoBehaviour
{
    public CardInfo parentInfo;

    private void Awake()
    {
        parentInfo = GetComponentInParent<CardInfo>();
    }


    //+BTN을 클릭하면 해당 이동 카드를 CardQueue에 추가합니다.
    public void PlusCard()
    {
        //현재 사용되고 있는 이미지가 있는지 확인하고 cardQueue에 추가한다.
        if (parentInfo.order.Count == 0 || parentInfo.cardOrderImg.activeSelf == false)
        {
            parentInfo.cardOrderImg.GetComponent<Image>().sprite = parentInfo.cardMgr.sprites[parentInfo.order.Count];
            parentInfo.cardOrderImg.SetActive(true);//첫 번쨰 이미지 사용

            parentInfo.order.Add(parentInfo.cardObj);
            //parentInfo.cardMgr.SetSelectedCard();
        }

        else if (parentInfo.order.Count == 1)
        {
            parentInfo.cardOrderImg2.GetComponent<Image>().sprite = parentInfo.cardMgr.sprites[parentInfo.order.Count];
            parentInfo.cardOrderImg2.SetActive(true);//두 번째 이미지 사용

            parentInfo.order.Add(parentInfo.cardObj);
        }

        else
        {
            parentInfo.cardOrderImg3.GetComponent<Image>().sprite = parentInfo.cardMgr.sprites[parentInfo.order.Count];
            parentInfo.cardOrderImg3.SetActive(true);

            parentInfo.order.Add(parentInfo.cardObj);
        }

        Destroy(parentInfo.plusCardBTN);
        Destroy(parentInfo.minusCardBTN);

        parentInfo.cardMgr.SetSelectedCard();

        parentInfo.cardMgr.isBTNOpened = false;
    }

    //해당 카드를 cardQueue에서 삭제한다.
    public void MinusCard()
    {
        GameObject currImg; //현재 사용되고 있는 이미지를 저장하는 변수
        int currIdx;        //해당 카드가 cardQueue에서 어느 인덱스에 존재하는지를 저장하는 변수

        if (parentInfo.order.Count == 3)
        {
            currImg = GetCurrImage();
            currIdx = GetCurrIdx();

            parentInfo.order.RemoveAt(currIdx); 
            parentInfo.cardMgr.DeleteSelectedCard();

            if (IsImgOpenMore2())
                currImg.SetActive(false);
            else
                parentInfo.cardOrderImg.SetActive(false);
            parentInfo.cardMgr.ChangeOrderImg();
        }

        else if (parentInfo.order.Count == 2)
        {
            currImg = GetCurrImage();
            currIdx = GetCurrIdx();

            parentInfo.order.RemoveAt(currIdx); 
            parentInfo.cardMgr.DeleteSelectedCard();

            if (IsImgOpenMore2())
                currImg.SetActive(false); 
            else
                parentInfo.cardOrderImg.SetActive(false);
            parentInfo.cardMgr.ChangeOrderImg();
        }

        else
        {
            currImg = GetCurrImage();
            currIdx = GetCurrIdx();

            parentInfo.order.RemoveAt(currIdx); 
            parentInfo.cardMgr.DeleteSelectedCard();

            if (IsImgOpenMore2())
                currImg.SetActive(false); 
            else
                parentInfo.cardOrderImg.SetActive(false);
            parentInfo.cardMgr.ChangeOrderImg();
        }

        Destroy(parentInfo.plusCardBTN);
        Destroy(parentInfo.minusCardBTN);
        parentInfo.cardMgr.isBTNOpened = false;
    }

    //현재 사용되고 있는 이미지가 무엇인지를 저장하는 함수입니다.
    GameObject GetCurrImage()
    {
        int imgIdx;
        for(int i= parentInfo.order.Count - 1; i>=0; i--)
            if(parentInfo.order[i] == parentInfo.cardObj)
            {
                imgIdx = i;

                if (imgIdx == 0)
                    return parentInfo.cardOrderImg;
                else if (imgIdx == 1)
                    return parentInfo.cardOrderImg2;
                else if (imgIdx == 2)
                    return parentInfo.cardOrderImg3;
                else
                    Debug.Log("CardBTN error");
            }

        return null;
    }

    //현재 부모카드가 CardQueue에서 어느 인덱스를 가지는지 리턴합니다.
    int GetCurrIdx()
    {
        int imgIdx;
        for (int i = parentInfo.order.Count - 1; i >= 0; i--)
            if (parentInfo.order[i] == parentInfo.cardObj)
            {
                imgIdx = i;

                return imgIdx;
            }

        return -1;
    }
    bool IsImgOpenMore2()
    {
        int count = 0;

        if (parentInfo.cardOrderImg.activeSelf) count++;
        if (parentInfo.cardOrderImg2.activeSelf) count++;
        if (parentInfo.cardOrderImg3.activeSelf) count++;

        if (count >= 2)
            return true;
        else return false;
    }
}
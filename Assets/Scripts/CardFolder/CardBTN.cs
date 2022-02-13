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

    //+버튼을 누르면 해당 카드의 순서 이미지를 출력하고 카드 큐에 삽입합니다.
    public void PlusCard()
    {
        // 큐의 마지막 인덱스 번호 = 카드 번호. 해당 번호의 이미지 불러옴.
        if (parentInfo.order.Count == 0 || parentInfo.cardOrderImg.activeSelf == false)
        {
            parentInfo.cardOrderImg.GetComponent<Image>().sprite = parentInfo.cardMgr.sprites[parentInfo.order.Count];
            parentInfo.cardOrderImg.SetActive(true);// 이미지 나타나게 함.
            parentInfo.order.Add(parentInfo.cardObj); // 해당 카드 번호 큐에 삽입
        }

        else if (parentInfo.order.Count == 1)
        {
            parentInfo.cardOrderImg2.GetComponent<Image>().sprite = parentInfo.cardMgr.sprites[parentInfo.order.Count];
            parentInfo.cardOrderImg2.SetActive(true);// 이미지 나타나게 함.
            parentInfo.order.Add(parentInfo.cardObj); // 해당 카드 번호 큐에 삽입
        }

        else
        {
            parentInfo.cardOrderImg3.GetComponent<Image>().sprite = parentInfo.cardMgr.sprites[parentInfo.order.Count];
            parentInfo.cardOrderImg3.SetActive(true);// 이미지 나타나게 함.
            parentInfo.order.Add(parentInfo.cardObj); // 해당 카드 번호 큐에 삽입
        }
        //parentInfo.isSelected = true;

        Destroy(parentInfo.plusCardBTN);
        Destroy(parentInfo.minusCardBTN);
        parentInfo.cardMgr.isBTNOpened = false;
    }

    //-버튼을 누르면 해당 카드의 순서 이미지를 제거하고 사용 카드 큐에서 삭제합니다.
    public void MinusCard()
    {
        GameObject currImg; //현재 카드에서 나타나는 순서 이미지를 저장할 변수입니다.
        int currIdx;        //제거하고 싶은 카드가 CardInfo의 order 리스트에서 몇 번째 인덱스를 가진 카드인지 저장할 변수입니다.

        if (parentInfo.order.Count == 3)
        {
            currImg = GetCurrImage();   //cardOrderImg,2,3 중 제거할, 카드의 순서를 담고 있는 오브젝트를 찾아 담습니다.
            currIdx = GetCurrIdx();

            parentInfo.order.RemoveAt(currIdx); //해당 카드의 번호 큐에서 삭제
            if(IsImgOpenMore2())
                currImg.SetActive(false); // 이미지 없앰.
            else
                parentInfo.cardOrderImg.SetActive(false);
            parentInfo.cardMgr.ChangeOrderImg();
        }

        else if (parentInfo.order.Count == 2)
        {
            currImg = GetCurrImage();
            currIdx = GetCurrIdx();

            parentInfo.order.RemoveAt(currIdx); //해당 카드의 번호 큐에서 삭제
            if (IsImgOpenMore2())
                currImg.SetActive(false); // 이미지 없앰.
            else
                parentInfo.cardOrderImg.SetActive(false);
            parentInfo.cardMgr.ChangeOrderImg();
        }

        else
        {
            currImg = GetCurrImage();
            currIdx = GetCurrIdx();

            parentInfo.order.RemoveAt(currIdx); //해당 카드의 번호 큐에서 삭제
            if (IsImgOpenMore2())
                currImg.SetActive(false); // 이미지 없앰.
            else
                parentInfo.cardOrderImg.SetActive(false);
            parentInfo.cardMgr.ChangeOrderImg();
        }

        Destroy(parentInfo.plusCardBTN);
        Destroy(parentInfo.minusCardBTN);
        parentInfo.cardMgr.isBTNOpened = false;
    }

    //카드 순서 이미지를 가진 오브젝트를 CardInfo에서 찾아 반환합니다.
    //반환할 이미지 오브젝트는 CardOrderImg, CardOrderImg2, CardOrderImg3 입니다.
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

    //현재 사용 카드 큐에서 클릭한 카드가 CardInfo의 order에서 몇 번째 인덱스를 가지는지 찾아 해당 인덱스를 출력합니다.
    //ex) 
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
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

//요로시꾸
    //+��ư�� ������ �ش� ī���� ���� �̹����� ����ϰ� ī�� ť�� �����մϴ�.
    public void PlusCard()
    {
        // ť�� ������ �ε��� ��ȣ = ī�� ��ȣ. �ش� ��ȣ�� �̹��� �ҷ���.
        if (parentInfo.order.Count == 0 || parentInfo.cardOrderImg.activeSelf == false)
        {
            parentInfo.cardOrderImg.GetComponent<Image>().sprite = parentInfo.cardMgr.sprites[parentInfo.order.Count];
            parentInfo.cardOrderImg.SetActive(true);// �̹��� ��Ÿ���� ��.
            parentInfo.order.Add(parentInfo.cardObj); // �ش� ī�� ��ȣ ť�� ����
            parentInfo.cardMgr.SetSelectedCard();
        }

        else if (parentInfo.order.Count == 1)
        {
            parentInfo.cardOrderImg2.GetComponent<Image>().sprite = parentInfo.cardMgr.sprites[parentInfo.order.Count];
            parentInfo.cardOrderImg2.SetActive(true);// �̹��� ��Ÿ���� ��.
            parentInfo.order.Add(parentInfo.cardObj); // �ش� ī�� ��ȣ ť�� ����
            parentInfo.cardMgr.SetSelectedCard();
        }

        else
        {
            parentInfo.cardOrderImg3.GetComponent<Image>().sprite = parentInfo.cardMgr.sprites[parentInfo.order.Count];
            parentInfo.cardOrderImg3.SetActive(true);// �̹��� ��Ÿ���� ��.
            parentInfo.order.Add(parentInfo.cardObj); // �ش� ī�� ��ȣ ť�� ����
            parentInfo.cardMgr.SetSelectedCard();
        }
        //parentInfo.isSelected = true;

        Destroy(parentInfo.plusCardBTN);
        Destroy(parentInfo.minusCardBTN);
        parentInfo.cardMgr.isBTNOpened = false;
    }

    //-��ư�� ������ �ش� ī���� ���� �̹����� �����ϰ� ��� ī�� ť���� �����մϴ�.
    public void MinusCard()
    {
        GameObject currImg; //���� ī�忡�� ��Ÿ���� ���� �̹����� ������ �����Դϴ�.
        int currIdx;        //�����ϰ� ���� ī�尡 CardInfo�� order ����Ʈ���� �� ��° �ε����� ���� ī������ ������ �����Դϴ�.

        if (parentInfo.order.Count == 3)
        {
            currImg = GetCurrImage();   //cardOrderImg,2,3 �� ������, ī���� ������ ��� �ִ� ������Ʈ�� ã�� ����ϴ�.
            currIdx = GetCurrIdx();

            parentInfo.order.RemoveAt(currIdx); //�ش� ī���� ��ȣ ť���� ����
            parentInfo.cardMgr.DeleteSelectedCard();
            if (IsImgOpenMore2())
                currImg.SetActive(false); // �̹��� ����.
            else
                parentInfo.cardOrderImg.SetActive(false);
            parentInfo.cardMgr.ChangeOrderImg();
        }

        else if (parentInfo.order.Count == 2)
        {
            currImg = GetCurrImage();
            currIdx = GetCurrIdx();

            parentInfo.order.RemoveAt(currIdx); //�ش� ī���� ��ȣ ť���� ����
            parentInfo.cardMgr.DeleteSelectedCard();
            if (IsImgOpenMore2())
                currImg.SetActive(false); // �̹��� ����.
            else
                parentInfo.cardOrderImg.SetActive(false);
            parentInfo.cardMgr.ChangeOrderImg();
        }

        else
        {
            currImg = GetCurrImage();
            currIdx = GetCurrIdx();

            parentInfo.order.RemoveAt(currIdx); //�ش� ī���� ��ȣ ť���� ����
            parentInfo.cardMgr.DeleteSelectedCard();
            if (IsImgOpenMore2())
                currImg.SetActive(false); // �̹��� ����.
            else
                parentInfo.cardOrderImg.SetActive(false);
            parentInfo.cardMgr.ChangeOrderImg();
        }

        Destroy(parentInfo.plusCardBTN);
        Destroy(parentInfo.minusCardBTN);
        parentInfo.cardMgr.isBTNOpened = false;
    }

    //ī�� ���� �̹����� ���� ������Ʈ�� CardInfo���� ã�� ��ȯ�մϴ�.
    //��ȯ�� �̹��� ������Ʈ�� CardOrderImg, CardOrderImg2, CardOrderImg3 �Դϴ�.
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

    //���� ��� ī�� ť���� Ŭ���� ī�尡 CardInfo�� order���� �� ��° �ε����� �������� ã�� �ش� �ε����� ����մϴ�.
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
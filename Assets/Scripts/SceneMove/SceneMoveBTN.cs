using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveBTN : MonoBehaviour
{
    //시마스
    //���������� ���� �̵��ϰ� ����� ���� ���� �ڵ�� �Դϴ�.
    //���߿� ������ ����!

    //1. MainMenu BTN �Լ���
    public void ClickStartFirstBTN()
    {
        //������ �� �� �ó����� �� ��� ĳ���� ���� ������ �̵�
        SceneManager.LoadScene("SelectStriker");
    }

    public void ClickBattleHistoryBTN()
    {
        SceneManager.LoadScene("BattleHistory");
    }

    public void ClickExitBTN()
    {
        Application.Quit();
    }

    //2. BattleHistory BTN �Լ���
    public void ClickExitBTN2MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //3. SelectStriker BTN �Լ���
    public void ClickSelectCardBTN()
    {
        SceneManager.LoadScene("SelectCard");
    }

    //4. SelectCard BTN �Լ���
    public void ClickCardBatteBTN()
    {
        SceneManager.LoadScene("CardBattleScene");
    }
}

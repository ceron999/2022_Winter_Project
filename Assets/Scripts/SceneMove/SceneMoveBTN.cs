using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveBTN : MonoBehaviour
{
    //���������� ���� �̵��ϰ� ����� ���� ���� �ڵ�� �Դϴ�.
    //���߿� ������ ����!

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

    public void ClickExitBTN2MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ClickSelectCardBTN()
    {
        SceneManager.LoadScene("SelectCard");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMoveBTN : MonoBehaviour
{
    //1. MainMenu BTN
    public void ClickStartFirstBTN()
    {
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

    //2. BattleHistory BTN
    public void ClickExitBTN2MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //3. SelectStriker BTN
    public void ClickSelectCardBTN()
    {
        SceneManager.LoadScene("SelectCard");
    }

    //4. SelectCard BTN
    public void ClickCardBatteBTN()
    {
        SceneManager.LoadScene("CardBattleScene");
    }
}

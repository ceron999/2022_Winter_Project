using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveBTN : MonoBehaviour
{
    //임의적으로 씬을 이동하게 만들기 위해 만든 코드들 입니다.
    //나중에 수정할 예정!

    public void ClickStartFirstBTN()
    {
        //구현이 덜 된 시나리오 씬 대신 캐릭터 선택 씬으로 이동
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

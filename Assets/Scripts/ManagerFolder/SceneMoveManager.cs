using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMoveManager : MonoBehaviour
{
    //조건부 이동을 담당한 씬 이동 매니저입니다.
    public static SceneMoveManager sceneMoveManager;
    public CardManager cardManager;

    //cardManager.cardQueue.Count == 3이면 배틀버튼 활성화를 만들기 위한 변수
    [SerializeField] GameObject battleStartBTN;
    Button battleStartBTNComponent;

    private void Awake()
    {
        //매니저가 존재하지 않으면 현재 오브젝트를 싱글톤으로 생성합니다.
        if (sceneMoveManager == null)
        {
            sceneMoveManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        cardManager = CardManager.cardManager;

        battleStartBTNComponent = battleStartBTN.GetComponent<Button>();
        battleStartBTNComponent.interactable = false;
    }

    public void SetBattleStartBTN()
    {
        if (cardManager.cardQueue.Count == 3)
            battleStartBTNComponent.interactable = true;
        else
            battleStartBTNComponent.interactable = false;
    }
}

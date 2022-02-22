using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMoveManager : MonoBehaviour
{
    //���Ǻ� �̵��� ����� �� �̵� �Ŵ����Դϴ�.
    public static SceneMoveManager sceneMoveManager;
    public CardManager cardManager;

    //cardManager.cardQueue.Count == 3�̸� ��Ʋ��ư Ȱ��ȭ�� ����� ���� ����
    [SerializeField] GameObject battleStartBTN;
    Button battleStartBTNComponent;

    private void Awake()
    {
        //�Ŵ����� �������� ������ ���� ������Ʈ�� �̱������� �����մϴ�.
        if (sceneMoveManager == null)
        {
            sceneMoveManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (battleStartBTN == null) Debug.Log(1);
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

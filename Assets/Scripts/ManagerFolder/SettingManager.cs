using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    public GameManager gameManager;
    public CardManager cardMgr;

    public GameObject firstCardPos;
    public GameObject secondCardPos;
    public GameObject thirdCardPos;
    public GameObject forthCardPos;
    public GameObject fifthCardPos;
    public GameObject sixthCardPos;

    public GameObject player;
    public GameObject enemy;


    private void Start()
    {
        gameManager = GameManager.gameManager;
        cardMgr = CardManager.cardManager;
        gameManager.cardMgr = cardMgr;
        gameManager.firstCardPos = firstCardPos;
        gameManager.secondCardPos = secondCardPos;
        gameManager.thirdCardPos = thirdCardPos;
        gameManager.forthCardPos = forthCardPos;
        gameManager.fifthCardPos = fifthCardPos;
        gameManager.sixthCardPos = sixthCardPos;

        gameManager.player = player;
        gameManager.enemy = enemy;
        gameManager.playerInfo = player.GetComponent<Character>();
        gameManager.enemy1Info = player.GetComponent<Enemy1>();
    }
}

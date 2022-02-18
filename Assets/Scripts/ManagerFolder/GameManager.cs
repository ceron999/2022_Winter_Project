using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //오네가이
    public static GameManager gameManager;

    public List<GameObject> inGameCardOrder;
    [SerializeField] CardManager cardmgr;
    [SerializeField] Character player;
    //[SerializeField] Enemy enemy;


    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //void enqueue() // 플레이어 1차이 = 에너미 2차이 => 플레이어에 가중치 1 부여 후 계산
    //{
    //    List<GameObject> big;
    //    List<GameObject> small;
    //    int gap = player.Speed + 1 - enemy.Speed; // player에 가중치 1 더함.
    //    if (gap > 0)
    //    {
    //        big = cardmgr.cardQueue;
    //        small = enemy.cardQueue;
    //    }
    //    else
    //    {
    //        big = enemy.cardQueue;
    //        small = cardmgr.cardQueue;
    //    }
    //    if (gap == 1) // BSBSBS
    //    {
    //        for (int i = 0; i < 3; i++)
    //        {
    //            inGameCardOrder.Add(big[i]);
    //            inGameCardOrder.Add(small[i]);
    //        }
    //    }
    //    else if (gap == 2) // BBSBSS  BBBSSS 하고 가운데 바꿈
    //    {
    //        for (int i = 0; i < 3; i++) inGameCardOrder.Add(big[i]);
    //        for (int i = 0; i < 3; i++) inGameCardOrder.Add(small[i]);
    //        GameObject tmp = inGameCardOrder[2];
    //        inGameCardOrder[2] = inGameCardOrder[3];
    //        inGameCardOrder[3] = tmp;
    //    }
    //    else //BBBSSS
    //    {
    //        for (int i = 0; i < 3; i++) inGameCardOrder.Add(big[i]);
    //        for (int i = 0; i < 3; i++) inGameCardOrder.Add(small[i]);
    //    }
    //}

    //public void instanciateCards()
    //{
    //    GameObject cards;
    //    for (int i = 0; i < 6; i++) // 카드 생성 후 위치에 맞게 넣음
    //    {
    //        cards = Instantiate(inGameCardOrder[i], transform.position, Quaternion.identity);

    //        cards.transform.localPosition = new Vector3(-400 + (135 * i), -166, 0);
    //    }
    //}
}

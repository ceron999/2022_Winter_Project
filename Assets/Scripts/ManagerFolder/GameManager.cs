using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
<<<<<<< Updated upstream
    /*
    함수에 관한 내용은 주석으로 꼭!!!!!!!!!!!!!!!!!!!!!!! 써주세요!!!!
     */
=======
    [SerializeField] CardManager cardmgr;
    [SerializeField] Character player;
    [SerializeField] Enemy enemy;
>>>>>>> Stashed changes
    public static GameManager gameManager;
    public List<GameObject> inGameCardOrder;
    void Awake()
    {
        gameManager = this;
    }

    void enqueue() // �뵆�젅�씠�뼱 1李⑥씠 = �뿉�꼫誘� 2李⑥씠 => �뵆�젅�씠�뼱�뿉 媛�以묒튂 1 遺��뿬 �썑 怨꾩궛
    {
        List<GameObject> big;
        List<GameObject> small;
        int gap = player.Speed + 1 - enemy.Speed; // player�뿉 媛�以묒튂 1 �뜑�븿.
        if(gap > 0)
        {
            big = cardmgr.cardQueue;
            small = enemy.cardQueue;
        }
        else
        {
            big = enemy.cardQueue;
            small = cardmgr.cardQueue;
        }
        if(gap == 1) // BSBSBS
        {
            for (int i = 0; i < 3; i++)
            {
                inGameCardOrder.Add(big[i]);
                inGameCardOrder.Add(small[i]);
            }
        }
        else if(gap == 2) // BBSBSS  BBBSSS �븯怨� 媛��슫�뜲 諛붽퓞
        {
            for (int i = 0; i < 3; i++)inGameCardOrder.Add(big[i]);
            for (int i = 0; i < 3; i++)inGameCardOrder.Add(small[i]);
            GameObject tmp = inGameCardOrder[2];
            inGameCardOrder[2] = inGameCardOrder[3];
            inGameCardOrder[3] = tmp;
        }
        else //BBBSSS
        {
            for (int i = 0; i < 3; i++)inGameCardOrder.Add(big[i]);
            for (int i = 0; i < 3; i++)inGameCardOrder.Add(small[i]);
        }
    }

    public void instanciateCards()
    {
        GameObject cards;
        for (int i = 0; i < 6; i++) // 移대뱶 �깮�꽦 �썑 �쐞移섏뿉 留욊쾶 �꽔�쓬
        {
            cards = Instantiate(inGameCardOrder[i], transform.position, Quaternion.identity);

            cards.transform.localPosition = new Vector3(-400 + (135 * i), -166, 0); 
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
<<<<<<< Updated upstream
    /*
    ÇÔ¼ö¿¡ °üÇÑ ³»¿ëÀº ÁÖ¼®À¸·Î ²À!!!!!!!!!!!!!!!!!!!!!!! ½áÁÖ¼¼¿ä!!!!
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

    void enqueue() // í”Œë ˆì´ì–´ 1ì°¨ì´ = ì—ë„ˆë¯¸ 2ì°¨ì´ => í”Œë ˆì´ì–´ì— ê°€ì¤‘ì¹˜ 1 ë¶€ì—¬ í›„ ê³„ì‚°
    {
        List<GameObject> big;
        List<GameObject> small;
        int gap = player.Speed + 1 - enemy.Speed; // playerì— ê°€ì¤‘ì¹˜ 1 ë”í•¨.
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
        else if(gap == 2) // BBSBSS  BBBSSS í•˜ê³  ê°€ìš´ë° ë°”ê¿ˆ
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
        for (int i = 0; i < 6; i++) // ì¹´ë“œ ìƒì„± í›„ ìœ„ì¹˜ì— ë§ê²Œ ë„£ìŒ
        {
            cards = Instantiate(inGameCardOrder[i], transform.position, Quaternion.identity);

            cards.transform.localPosition = new Vector3(-400 + (135 * i), -166, 0); 
        }
    }

}

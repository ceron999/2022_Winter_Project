using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
    함수에 관한 내용은 주석으로 꼭!!!!!!!!!!!!!!!!!!!!!!! 써주세요!!!!
     */
    public static GameManager gameManager;
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

}

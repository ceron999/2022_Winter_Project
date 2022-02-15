using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
    �Լ��� ���� ������ �ּ����� ��!!!!!!!!!!!!!!!!!!!!!!! ���ּ���!!!!
     */
     //오네가이
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

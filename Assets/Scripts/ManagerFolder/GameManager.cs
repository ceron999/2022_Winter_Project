using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
    �Լ��� ���� ������ �ּ����� ��!!!!!!!!!!!!!!!!!!!!!!! ���ּ���!!!!
     */
    public static GameManager gameManager;
    void Awake()
    {
        gameManager = this;
    }

}

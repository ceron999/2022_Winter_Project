using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour
{
    public Sprite enemyImg;
    public string enemyDetail;
    public string Character_Name;
    public int Health;
    public int Speed = 1;
    public Vector3 expPos;
    public struct PosArr
    {
        public int xPos;
        public int yPos;
        public int attackCount; // 스킬 공격 겹치는 횟수
    }
    public PosArr[,] enemyPosArr = new PosArr[5,5];
    void Start()
    {
        for (int i = 0; i < 5; i++) // -4,2 (왼쪽 대각선 두 칸 위) 부터 4,-2 (오른쪽 대각선 두 칸 아래)
        {
            for (int j = 0; j < 5; j++)
            {
                enemyPosArr[i, j].xPos = -4 + (j * 2);
                enemyPosArr[i, j].yPos = 2 - i;
                enemyPosArr[i, j].attackCount = 0;
            }
        }
    }
}

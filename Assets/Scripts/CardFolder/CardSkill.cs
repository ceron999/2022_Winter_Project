using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSkill : MonoBehaviour
{
    public GameManager gameManager;
    /// 캐릭터 포지션 기준 타일 위치.
    /// (-4, 2)  (-2, 2)  ( 0, 2)  ( 2, 2)  ( 4, 2)
    /// (-4, 1)  (-2, 1)  ( 0, 1)  ( 2, 1)  ( 4, 1)
    /// (-4, 0)  (-2, 0)  ( 0, 0)  ( 2, 0)  ( 4, 0)
    /// (-4,-1)  (-2,-1)  ( 0,-1)  ( 2,-1)  ( 4,-1)
    /// (-4,-2)  (-2,-2)  ( 0,-2)  ( 2,-2)  ( 4,-2)
    
    ///각 포지션 인덱스 (12가 캐릭터 기준)
    /// 0  1  2  3  4
    /// 5  6  7  8  9
    ///10 11 12 13 14
    ///15 16 17 18 19
    ///20 21 22 23 24

    public List<Vector3> rangeVector;
    public static int[][] skillsIdx;

    private void Start()
    {
        gameManager = GameManager.gameManager;
        SetRangeVector();
        
        if (skillsIdx == null)
            SetSkillsIdx();
    }

    void SetRangeVector()
    {
        Vector3 temp = new Vector3(-4, 2, 0);
        Vector3 xPosUp = new Vector3(2, 0, 0);
        Vector3 yPosDown = new Vector3(0, -1, 0);

        rangeVector.Add(temp);
        for(int i=1; i<25;i++)
        {
            if (i % 5 != 0)
                rangeVector.Add(temp + (xPosUp * (i%5)));
            else
            {
                temp = temp + yPosDown;
                rangeVector.Add(temp);
            }
        }
    }

    void SetSkillsIdx()
    {
        //나중에 json파일로 따로 저장할 변수이니 사용금지.
        skillsIdx = new int[12][];


        //길버트 cardNum/100 ==1 && cardNum%100 == skillsidx 첫 인덱스
        skillsIdx[0] = new int[] { 6, 7, 8, 13 };
        skillsIdx[1] = new int[] { 6, 7, 8 };
        skillsIdx[2] = new int[] { 8, 18 };
        skillsIdx[3] = new int[] { 7, 11, 12, 13, 17 };
        skillsIdx[4] = new int[] { 6, 7, 8, 11, 13 };
        skillsIdx[5] = new int[] { 13 };
        skillsIdx[6] = new int[] { 6, 11, 16 };
        skillsIdx[7] = new int[] { 18, 24 };
        skillsIdx[8] = new int[] { 7 };  //상
        skillsIdx[9] = new int[] { 17 };   //하
        skillsIdx[10] = new int[] { 11 };  //좌
        skillsIdx[11] = new int[] { 13 };  //우
    }

    public void Skill(int getCardNumber)
    {
        int getSkillsIdx = getCardNumber % 100;
        int rangeCount = skillsIdx[getSkillsIdx].Length;
        int vectorIdx;

        for(int i=0;i<rangeCount;i++)
        {
            vectorIdx = skillsIdx[getSkillsIdx][i];
            Debug.Log(vectorIdx + " Skill : "+ rangeVector[vectorIdx]);

            //hit함수가 들어가면 되지 않을까 생각중입니다.
        }
    }

    public void Move(int getCardNumber)
    {
        int getSkillsIdx = getCardNumber % 100;
        int rangeCount = skillsIdx[getSkillsIdx].Length;
        int vectorIdx;

        for (int i = 0; i < rangeCount; i++)
        {
            vectorIdx = skillsIdx[getSkillsIdx][i];
            Debug.Log(vectorIdx + "  Move : " + rangeVector[vectorIdx]);

            gameManager.player.transform.position += rangeVector[vectorIdx];
        }
    }
}

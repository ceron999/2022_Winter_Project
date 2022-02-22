using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSkill : MonoBehaviour
{
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

    public List<Vector2> rangeVector;
    //List<int> getRangeList;

    private void Start()
    {
        SetRangeVector();
    }

    void SetRangeVector()
    {
        Vector2 temp = new Vector2(-4, 2);
        Vector2 xPosUp = new Vector2(2, 0);
        Vector2 yPosDown = new Vector2(0, -1);

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

    public void Skill()
    {
    }

    public void Move()
    {
        
    }
}

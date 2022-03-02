using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum Direction
{
    left = 1,
    right,
    up,
    down,
}

public enum SkillType
{
    move = 1,
    heal,
    attack,
}
public struct Skill
{
    Direction dir;
    int dmg;
    int heal;
    List<Dictionary<int, int>> range;
}

public class PatricSkill : MonoBehaviour
{
    [SerializeField] Enemy1 enemy;
    [SerializeField] Character player;
    void Start()
    {
        AttackCountInit();
        
    }
    void AttackCountInit() // [2,2]이 본인 위치
    {
        //Skill1
        enemy.enemyPosArr[1, 1].attackCount++;
        enemy.enemyPosArr[3, 1].attackCount++;
        enemy.enemyPosArr[1, 3].attackCount++;
        enemy.enemyPosArr[3, 3].attackCount++;
        enemy.enemyPosArr[2, 2].attackCount++;
        //Skill2
        enemy.enemyPosArr[1, 1].attackCount++;
        enemy.enemyPosArr[1, 2].attackCount++;
        enemy.enemyPosArr[1, 3].attackCount++;
        enemy.enemyPosArr[2, 1].attackCount++;
        enemy.enemyPosArr[2, 3].attackCount++;
        enemy.enemyPosArr[3, 1].attackCount++;
        enemy.enemyPosArr[3, 2].attackCount++;
        enemy.enemyPosArr[3, 1].attackCount++;
        //Skill3
        enemy.enemyPosArr[1, 1].attackCount++;
        enemy.enemyPosArr[1, 2].attackCount++;
        enemy.enemyPosArr[2, 3].attackCount++;
        enemy.enemyPosArr[3, 1].attackCount++;
        enemy.enemyPosArr[3, 2].attackCount++;
        //Skill4
        enemy.enemyPosArr[2, 1].attackCount++;
        //Skill5
        enemy.enemyPosArr[2, 2].attackCount++;
        enemy.enemyPosArr[2, 3].attackCount++;
        enemy.enemyPosArr[3, 3].attackCount++;
        //Skill6
        enemy.enemyPosArr[1, 1].attackCount++;
        enemy.enemyPosArr[2, 3].attackCount++;
        enemy.enemyPosArr[3, 1].attackCount++;
        //Skill7
        enemy.enemyPosArr[0, 0].attackCount++;
        enemy.enemyPosArr[0, 3].attackCount++;
        enemy.enemyPosArr[1, 1].attackCount++;
        enemy.enemyPosArr[1, 3].attackCount++;
        //Skill8
        enemy.enemyPosArr[1, 2].attackCount++;
        enemy.enemyPosArr[1, 4].attackCount++;
        enemy.enemyPosArr[2, 2].attackCount++;
        enemy.enemyPosArr[3, 2].attackCount++;
        enemy.enemyPosArr[3, 4].attackCount++;
    }
    void Move(int Direction)
    {
        Vector3 curPos = enemy.transform.position;
        switch(Direction)
        {
            case 1:
                enemy.transform.position = new Vector3(curPos.x - 2, curPos.y, curPos.z);
                break;
            case 2:
            enemy.transform.position = new Vector3(curPos.x + 2, curPos.y, curPos.z);
                break;
            case 3:
            enemy.transform.position = new Vector3(curPos.x, curPos.y + 1, curPos.z);
                break;
            case 4:
            enemy.transform.position = new Vector3(curPos.x, curPos.y - 1, curPos.z);
                break;
            default:
                break;
        }
    }
    // void ActiveSkill(Skill skillnum)
    // {
    //     player.hp += skillnum.heal;

    //     if(skillnum.dmg)
    //     {
    //         find(enemy.transform.position)
    //         enemy.hp -=
    //     }
    // }
}

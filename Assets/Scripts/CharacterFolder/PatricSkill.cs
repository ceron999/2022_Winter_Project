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
public class Pair // posArr의 index 저장
{
    public Pair(int i, int j) { a = i; b = j; }
    public int a;
    public int b;
}
public class Skill
{
    public Direction dir = 0;
    public int dmg = 0;
    public int heal = 0;
    public int cost = 0;
    public List<Pair> range; // 공격 범위
}
public class PatricSkill : MonoBehaviour
{
    [SerializeField] Enemy1 enemy;
    [SerializeField] Character player;
    List<Skill> skills;
    void Start()
    {
        SkillInit();
        AttackCountInit();
    }
    void SkillInit()
    {
        Skill voidSkill = new Skill();
        skills.Add(voidSkill);
        for (int i = 1; i < 9; i++)
        {
            Skill skill = new Skill();
            skills.Add(skill);
            gameObject.SendMessage($"SetSkill{i}({i})");
        }
    }

    void SetSkill1(int i)
    {
        skills[i].dmg = 20;
        skills[i].cost = 1;
        skills[i].range.Add(new Pair(1, 1)); // 2,2가 본인위치 
        skills[i].range.Add(new Pair(3, 1));
        skills[i].range.Add(new Pair(2, 2));
        skills[i].range.Add(new Pair(1, 3));
        skills[i].range.Add(new Pair(3, 3));
    }
    void SetSkill2(int i)
    {

    }
    void SetSkill3(int i)
    {

    }
    void SetSkill4(int i)
    {

    }
    void SetSkill5(int i)
    {

    }
    void SetSkill6(int i)
    {

    }
    void SetSkill7(int i)
    {

    }
    void SetSkill8(int i)
    {

    }
    void AttackCountInit() // [2,2]이 본인 위치
    {
        for (int i = 1; i < 9;i++)
        {
            for (int j = 0; j < skills[i].range.Count; j++)// 범위 개수만큼 해당
            {
                enemy.enemyPosArr[skills[i].range[j].a, skills[i].range[j].b].attackCount++;
            }
        }
        // //Skill1
        // enemy.enemyPosArr[1, 1].attackCount++;
        // enemy.enemyPosArr[3, 1].attackCount++;
        // enemy.enemyPosArr[1, 3].attackCount++;
        // enemy.enemyPosArr[3, 3].attackCount++;
        // enemy.enemyPosArr[2, 2].attackCount++;
        // //Skill2
        // enemy.enemyPosArr[1, 1].attackCount++;
        // enemy.enemyPosArr[1, 2].attackCount++;
        // enemy.enemyPosArr[1, 3].attackCount++;
        // enemy.enemyPosArr[2, 1].attackCount++;
        // enemy.enemyPosArr[2, 3].attackCount++;
        // enemy.enemyPosArr[3, 1].attackCount++;
        // enemy.enemyPosArr[3, 2].attackCount++;
        // enemy.enemyPosArr[3, 1].attackCount++;
        // //Skill3
        // enemy.enemyPosArr[1, 1].attackCount++;
        // enemy.enemyPosArr[1, 2].attackCount++;
        // enemy.enemyPosArr[2, 3].attackCount++;
        // enemy.enemyPosArr[3, 1].attackCount++;
        // enemy.enemyPosArr[3, 2].attackCount++;
        // //Skill4
        // enemy.enemyPosArr[2, 1].attackCount++;
        // //Skill5
        // enemy.enemyPosArr[2, 2].attackCount++;
        // enemy.enemyPosArr[2, 3].attackCount++;
        // enemy.enemyPosArr[3, 3].attackCount++;
        // //Skill6
        // enemy.enemyPosArr[1, 1].attackCount++;
        // enemy.enemyPosArr[2, 3].attackCount++;
        // enemy.enemyPosArr[3, 1].attackCount++;
        // //Skill7
        // enemy.enemyPosArr[0, 0].attackCount++;
        // enemy.enemyPosArr[0, 3].attackCount++;
        // enemy.enemyPosArr[1, 1].attackCount++;
        // enemy.enemyPosArr[1, 3].attackCount++;
        // //Skill8
        // enemy.enemyPosArr[1, 2].attackCount++;
        // enemy.enemyPosArr[1, 4].attackCount++;
        // enemy.enemyPosArr[2, 2].attackCount++;
        // enemy.enemyPosArr[3, 2].attackCount++;
        // enemy.enemyPosArr[3, 4].attackCount++;

    }
    void Move(int Direction)
    {
        Vector3 curPos = enemy.transform.position;
        switch(Direction)
        {
            case 1:
                enemy.transform.position = new Vector3(curPos.x + enemy.enemyPosArr[1, 2].xPos, curPos.y, curPos.z);
                break;
            case 2:
            enemy.transform.position = new Vector3(curPos.x + enemy.enemyPosArr[3, 2].xPos, curPos.y, curPos.z);
                break;
            case 3:
            enemy.transform.position = new Vector3(curPos.x, curPos.y + enemy.enemyPosArr[2, 1].yPos, curPos.z);
                break;
            case 4:
            enemy.transform.position = new Vector3(curPos.x, curPos.y + enemy.enemyPosArr[2, 3].yPos, curPos.z);
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

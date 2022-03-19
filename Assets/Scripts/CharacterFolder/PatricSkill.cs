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
    public int cooldown = 0;
    public bool isCool = false; 
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
        skills[i].cooldown = 1;
        skills[i].range.Add(new Pair(1, 1)); // 2,2가 본인위치 
        skills[i].range.Add(new Pair(3, 1));
        skills[i].range.Add(new Pair(2, 2));
        skills[i].range.Add(new Pair(1, 3));
        skills[i].range.Add(new Pair(3, 3));
    }
    void SetSkill2(int i)
    {
        skills[i].dmg = 25;
        skills[i].cooldown = 3;
        skills[i].range.Add(new Pair(1,1));
        skills[i].range.Add(new Pair(2,1));
        skills[i].range.Add(new Pair(3,1));
        skills[i].range.Add(new Pair(2,2));
        skills[i].range.Add(new Pair(3,2));
        skills[i].range.Add(new Pair(1,3));
        skills[i].range.Add(new Pair(2,3));
        skills[i].range.Add(new Pair(3,3));
    }
    void SetSkill3(int i)
    {
        skills[i].dmg = 20;
        skills[i].cooldown = 1;
        skills[i].range.Add(new Pair(1,1));
        skills[i].range.Add(new Pair(1,2));
        skills[i].range.Add(new Pair(3,2));
        skills[i].range.Add(new Pair(1,3));
        skills[i].range.Add(new Pair(2,3));
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
                enemy.posArr[skills[i].range[j].a, skills[i].range[j].b].attackCount++;
            }
        }
    }
    void Move(Direction dir)
    {
        Vector3 curPos = enemy.transform.position;
        Vector3 tmpPos = new Vector3(0, 0, 0);
        switch(dir)
        {
            case Direction.left:
                tmpPos = new Vector3(curPos.x + enemy.posArr[1, 2].xPos, curPos.y, curPos.z);
                break;
            case Direction.right:
                tmpPos = new Vector3(curPos.x + enemy.posArr[3, 2].xPos, curPos.y, curPos.z);
                break;
            case Direction.up:
                tmpPos = new Vector3(curPos.x, curPos.y + enemy.posArr[2, 1].yPos, curPos.z);
                break;
            case Direction.down:
                tmpPos = new Vector3(curPos.x, curPos.y + enemy.posArr[2, 3].yPos, curPos.z);
                break;
            default:
                break;
        }
        //예외처리. 맵 밖으로 나가는 포지션일 경우 실행하지않음
        if(tmpPos.x < -5.0f || tmpPos.x > 5.0f || tmpPos.y < -2.0f || tmpPos.y > 2.0f) return;
        else enemy.transform.position = tmpPos;
    }
    void ActiveSkill(int skillnum)
    {
        Skill skill = skills[skillnum];
        if(skill.dir != 0)
        {
            Move(skill.dir);
        }
        if(skill.heal > 0)
        {
            enemy.Health += skill.heal;
            if(enemy.Health > 100) enemy.Health = 100; //100 못 넘게함
        }
        if(skill.dmg != 0)
        {
            //player.Hit(skill.dmg);
        }
    }
    void Hit(int damage)
    {
        enemy.Health -= damage;
        if(enemy.Health < 0) GameObject.Destroy(this); //체력이 0이하로 떨어질 경우 사망.
        //enemy가 다 죽었을 경우 게임 종료하는 코드 삽입 필요
    }
}

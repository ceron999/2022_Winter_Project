using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    //파싱한 데이터를 데이터베이스에서 저장 및 관리
    public static DataBaseManager dataBaseManager;

    [SerializeField] string csvFileName;

    Dictionary<int,Dialogue> dialogueDictionary = new Dictionary<int,Dialogue>();
    public static bool isFinished = false;

    private void Awake()
    {
        //매니저가 존재하지 않으면 현재 오브젝트를 싱글톤으로 생성합니다.
        if (dataBaseManager == null)
        {
            dataBaseManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        DialogueParser theParser = GetComponent<DialogueParser>();
        Dialogue[] dialogues = theParser.Parse(csvFileName);

        for (int i = 0; i < dialogues.Length; i++)
        {
            dialogueDictionary.Add(i + 1, dialogues[i]);
        }
        isFinished = true;
    }


    void Update()
    {
        
    }

    public Dialogue[] GetDialogues(int startNum,int endNum)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();

        for(int i=0; i<= endNum - startNum; i++)
        {
            dialogueList.Add(dialogueDictionary[startNum + i]);
        }

        return dialogueList.ToArray();
    }
}

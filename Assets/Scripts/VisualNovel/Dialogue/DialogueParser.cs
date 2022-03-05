using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string csvFileName)
    {
        StringBuilder csvFilesNameBuilder;  //csv 파일의 이름을 기억하는 string builder

        string saveLocation = "VisualNovel/CSV/";   //parse하기를 원하는 데이터 위치

        csvFilesNameBuilder = new StringBuilder(saveLocation);
        csvFilesNameBuilder.Append(csvFileName);

        List<Dialogue> DialogueList = new List<Dialogue>(); //대사 리스트 생성
        TextAsset csvData = Resources.Load<TextAsset>(csvFilesNameBuilder.ToString());

        string[] data = csvData.text.Split(new char[] { '\n' });

        Dialogue dialogue = new Dialogue(); //대사 리스트 형성

        for (int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });   //현재 line을 ,단위로 잘라냄
            Debug.Log(csvFilesNameBuilder.ToString());
            dialogue.name = row[1];
            List<string> contextList = new List<string>();
            do
            {
                contextList.Add(row[2]);
                if (++i < data.Length)
                    row = data[i].Split(new char[] { ',' });    //다음 line을 ,단위로 잘라냄

                else
                    break;
            } while (row[0].ToString() == "");

            dialogue.context = contextList.ToArray();

            DialogueList.Add(dialogue);
        }

        return DialogueList.ToArray();
    }
}

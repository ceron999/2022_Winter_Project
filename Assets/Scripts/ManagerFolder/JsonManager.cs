using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class JsonManager : MonoBehaviour
{
    private void Start()
    {
        
        
    }

    public void SaveJson(Card cardData)
    {
        string jsonText;


        //�ȵ���̵忡���� ���� ��ġ�� �ٸ��� ���־�� �Ѵ�
        //Application.dataPath�� �̿��ϸ� ���� �������� ���۸� �غ��� �ٶ���
        //�ȵ���̵��� ��쿡�� ������������ �������� 2�������ͷ� ��ȯ�� �ؾ��Ѵ�

        string savePath = Application.dataPath;
        string appender = "/userData/";
        string nameString = "SaveData";
        string dotJson = ".json";

#if UNITY_EDITOR_WIN

#endif
#if UNITY_ANDROID
        //�̰ų��߿� ����ߵ�
        savePath = Application.persistentDataPath;
        Debug.Log(savePath);
#endif
        StringBuilder builder = new StringBuilder(savePath);
        builder.Append(appender);
        if (!Directory.Exists(builder.ToString()))
        {
            //���丮�� ���°�� ������ش�
            Directory.CreateDirectory(builder.ToString());

        }
        builder.Append(nameString);
        builder.Append(dotJson);

        jsonText = JsonUtility.ToJson(cardData, true);
        //�̷����� �ϴ� �����Ͱ� �ؽ�Ʈ�� ��ȯ�� �ȴ�
        //jsonUtility�� �̿��Ͽ� data�� WholeGameData�� json������ text�� �ٲپ��ش�

        //���Ͻ�Ʈ���� �̷��� �������ְ� �������ָ�ȴ� ��
        FileStream fileStream = new FileStream(builder.ToString(), FileMode.Create);
        byte[] bytes = Encoding.UTF8.GetBytes(jsonText);
        fileStream.Write(bytes, 0, bytes.Length);
        fileStream.Close();
    }

    public T ResourceDataLoad<T>(string name)
    {
        //���� �츮�� ������ �����ߴ� �����͸� �������Ѵ�
        //���� ������ �����Ͱ� ���ٸ�? �̰� ���� ���ϰ� Ʃ�丮���� �����ϸ� �׸��̴�. �� �۾��� ���δ����� ���ش�
        T gameData;
        string directory = "JsonData/";

        string appender1 = name;
        //        string appender2 = ".json";
        StringBuilder builder = new StringBuilder(directory);
        builder.Append(appender1);
        //      builder.Append(appender2);
        //�������� ���̺�� �Ȱ���
        //���Ͻ�Ʈ���� ������ش�. ���ϸ�带 open���� �ؼ� �����ش�. �� ���۸��̴�
        TextAsset jsonString = Resources.Load<TextAsset>(builder.ToString());
        Debug.Log(builder);
        gameData = JsonUtility.FromJson<T>(jsonString.ToString());

        return gameData;
        //�� ������ ���ӸŴ�����, �ε����� �Ѱ��ִ� ���̴�
    }
}

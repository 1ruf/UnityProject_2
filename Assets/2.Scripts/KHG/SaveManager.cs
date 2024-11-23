using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveManager : MonoBehaviour                    //0�� false �� 1�� true�� �Ե�
{
    private string filePath;

    public static SaveManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            return;
        }
    }
    private void Start()
    {
        StartDataSetting();
        //FileCreate();
    }

    public void StartDataSetting()
    {
        filePath = Path.Combine(Application.persistentDataPath, "DATA.txt");
        if (File.Exists(filePath) == false)
        {
            string startData = "";
            startData += "[������ ���� �źε�]\n";
            for (int i = 1; i < 100; i++)
            {
                startData += "0\n";
            }
            File.WriteAllText(filePath, startData);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetAllData();
        }
    }
    public void SetDatas(int startLine, int endLine, string value) //���۰� ���� �޾ƿͼ� �� �κи� �����ϱ�
    {
        //string[] Data = File.ReadAllLines(filePath);
        //for (int i = startLine; i <= endLine; i++)
        //{
        //    Data[i] = (value + "\n");
        //    File.WriteAllText(filePath, Data[i]);
        //    Debug.Log($"���� ��ü�Ǿ����ϴ�.\n��ü ��������:{startLine},��ü ��������:{endLine}.\n��ü�� ��:{value}");
        //}
    }
    public void ResetAllData()
    {
        string startData = "";
        startData += "[������ ���� �źε�]\n";
        for (int i = 1; i < 100; i++)
        {
            startData += "0\n";
        }
        File.WriteAllText(filePath, startData);
    }
    public void SetData(int path,bool value) //��ġ(���°��),��(0[false],1[true])����
    {
        try
        {
            string[] existingText = File.ReadAllLines(filePath);
            if (value == true) //���� true �� 1(true)����
            {
                existingText[path] = "1"; //��ġ�� ���� 1(true)�� ����
            }
            else               //���� false �� 0(false)����
            {
                existingText[path] = "0"; //��ġ�� ���� 1(true)�� ����
            }
            File.WriteAllLines(filePath, existingText); //���� �ٽþ���
            //(existingText[path - 1].Trim().ToLower() == "0") //�� ��(��ü)���� ���� �����Ͱ� �ִ��� Ȯ��
        }
        catch (IOException e)
        {
            Debug.LogError("���� �߰� �� ���� �߻�: " + e.Message);
        }
    }
    public void SetDataString(int path, string value)
    {
        try
        {
            string[] existingText = File.ReadAllLines(filePath);
            existingText[path] = value;
            File.WriteAllLines(filePath, existingText); //���� �ٽþ���
            //(existingText[path - 1].Trim().ToLower() == "0") //�� ��(��ü)���� ���� �����Ͱ� �ִ��� Ȯ��
        }
        catch (IOException e)
        {
            Debug.LogError("���� �߰� �� ���� �߻�: " + e.Message);
        }
    }
    public bool CheckData(int lineNum)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            bool value = (lines[lineNum].Trim().ToLower() == "1") ? true : false; //1(true) �̸� true ��ȯ, �ƴϸ� false ��ȯ
            return value;
        }
        catch (IOException error)
        {
            Debug.LogError("����: " + error.Message);
            return false;
        }
    }
    public T GetData<T>(int lineNum)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            return (T)Convert.ChangeType(lines[lineNum], typeof(T));
        }
        catch (IOException error)
        {
            Debug.LogError("����: " + error.Message);
            return (T)Convert.ChangeType("ERROR", typeof(T));
        }
    }
}
public enum Datas
{
    Username = 0,
    FirstEnter = 1,
    Setting_BGM = 5,
    Setting_SFX = 6,
    Cutscene1 = 10,
    Cutscene2 = 11,
    Cutscene3 = 12,
    Stage1 =    30,
    Stage2 =    31,
    Stage3 =    32,
    Stage4 =    33
}

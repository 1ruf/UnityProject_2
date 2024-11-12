using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour                    //0이 false 고 1이 true임 님들
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
        filePath = Path.Combine(Application.persistentDataPath, "DATA.txt");
        if (File.Exists(filePath) == false)
        {
            string startData = "";
            for (int i = 0; i < 100; i++)
            {
                startData += "0\n";
            }
            File.WriteAllText(filePath, startData);
        }
        //FileCreate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ResetAllData();
            }
        }
    }
    public void ResetData(int startLine, int endLine) //시작값 끝값 받아와서 그 부분만 수정하기
    {
        //string startData = "";
        //for (int i = startLine; i < endLine; i++)
        //{
        //    startData += "0\n";
        //}
        //File.WriteAllText(filePath, startData);
    }
    public void ResetAllData()
    {
        string startData = "";
        for (int i = 0; i < 100; i++)
        {
            startData += "0\n";
        }
        File.WriteAllText(filePath, startData);
    }
    public void SetData(int path,bool value) //위치(몇번째줄),값(0[false],1[true])설정
    {
        try
        {
            string[] existingText = File.ReadAllLines(filePath);
            if (value == true) //값이 true 면 1(true)저장
            {
                existingText[path - 1] = "1"; //위치에 값을 1(true)로 변경
            }
            else               //값이 false 면 0(false)저장
            {
                existingText[path - 1] = "0"; //위치에 값을 1(true)로 변경
            }
            File.WriteAllLines(filePath, existingText); //파일 다시쓰기
            //(existingText[path - 1].Trim().ToLower() == "0") //이 전(전체)에서 같은 데이터가 있는지 확인
        }
        catch (IOException e)
        {
            Debug.LogError("파일 추가 중 오류 발생: " + e.Message);
        }
    }
    public bool CheckData(int lineNum)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            bool value = (lines[lineNum - 1].Trim().ToLower() == "1") ? true : false; //1(true) 이면 true 반환, 아니면 false 반환
            return value;
        }
        catch (IOException error)
        {
            Debug.LogError("에러: " + error.Message);
            return false;
        }
    }

}

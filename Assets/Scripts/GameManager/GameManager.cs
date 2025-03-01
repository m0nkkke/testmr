using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameData
{
    public int MaxScore;
    public int MaxBananas;
    public int AllBananas;
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int roadSpeed = 8;
    public int Score = 0;
    public int Bananas = 0;
    public bool isRunning = true;

    private readonly string filename = "result.json";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        //if (isRunning)
        //{
        //    roadSpeed = roadSpeed + Score / (roadSpeed * 3);
        //}

    }
    public void ResetGame()
    {
        try
        {
            SaveResult();
        }
        catch { }
        Instance.Score = 0;
        Instance.Bananas = 0;
        isRunning = false;
    }

    public void SaveResult()
    {
        GameData data;

        // ���������, ���������� �� ����
        if (File.Exists(filename))
        {
            // ���� ���� ����������, ��������� ������ �� ����
            string json = File.ReadAllText(filename);
            data = JsonUtility.FromJson<GameData>(json);
            print(data);
        }
        else
        {
            // ���� ���� �� ����������, ������� ����� ������ GameData
            data = new GameData
            {
                MaxScore = 0,
                MaxBananas = 0,
                AllBananas = 0
            };
        }

        // ��������� ��������
        data.MaxScore = Math.Max(data.MaxScore, Instance.Score);
        data.MaxBananas = Math.Max(data.MaxBananas, Instance.Bananas);
        data.AllBananas += Instance.Bananas;

        // ��������� ����������� ������ � ����
        string updatedJson = JsonUtility.ToJson(data, true);
        File.WriteAllText(filename, updatedJson);
    }

    [ContextMenu("Restart")]
    public void Restart()
    {
        // �������� ������ ������� �����
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // ������������� ������� �����
        SceneManager.LoadScene(currentSceneIndex);
        roadSpeed = 8;
        isRunning = true;
    }


}

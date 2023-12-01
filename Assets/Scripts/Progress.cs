using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressData
{
    public int Score;
    public int Coins;
}

public class Progress : MonoBehaviour
{
    public int Score;
    public int Coins;

    public static Progress Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLevel(int score)
    {
        Score = score;
        Save();
    }

    public void AddCoins(int value)
    {
        Coins += value;
        Save();
    }

    public int ReturnCoins()
    {
        return Coins;
    }

    private void Save()
    {
        ProgressData progressData = new ProgressData();
        progressData.Score = Score;
        progressData.Coins = Coins;

        string json = JsonUtility.ToJson(progressData);
        PlayerPrefs.SetString("Progress", json);
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey("Progress"))
        {
            string json = PlayerPrefs.GetString("Progress");
            ProgressData progressData = JsonUtility.FromJson<ProgressData>(json);
            Score = progressData.Score;
            Coins = progressData.Coins;
        }
    }
}

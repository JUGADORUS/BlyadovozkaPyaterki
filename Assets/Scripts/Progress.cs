using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressData
{
    public int Score;
    public int Coins;
    public int BestScore;

    public bool RafikUnlocked = true;
    public bool NissanGTRUnlocked = false;
    public bool TaycanUnlocked = false;
    public bool GelikUnlocked = false;
    public bool CyberTruckUnlocked = false;
}

public class Progress : MonoBehaviour
{
    public int Score;
    public int Coins;
    public int BestScore;

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

    public void AddScore(int score)
    {
        Score += score;

        Save();
    }

    public void SaveBestScore(int bestScore)
    {
        BestScore = bestScore;
    }

    public void AddCoins(int value)
    {
        Coins += value;
        Save();
    }

    private void Save()
    {
        ProgressData progressData = new ProgressData();
        progressData.Score = Score;
        progressData.Coins = Coins;
        progressData.BestScore = BestScore;

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
            BestScore = progressData.BestScore;
        }
    }
}

using System;

using UnityEngine;

[System.Serializable]
public class ProgressData
{
    public bool[] CarsUnlockedDefault = { true, false, false, false, false, false };

    public int Score;
    public int Coins;
    public int BestScore;

    public bool[] CarsUnlocked;

    public static ProgressData GetEmptyProgressData()
    {
        ProgressData data = new ProgressData();
        data.Score = 0;
        data.BestScore = 0;
        data.Coins = 0;
        data.CarsUnlocked = new bool[] { true, false, false, false, false, false };
        return data;
    }

    public void FillEmptyValues()
    {
        if (CarsUnlocked == null) SetDefaultCars();
    }

    public void SetDefaultCars() { CarsUnlocked = CarsUnlockedDefault; }

    public bool IsCarUnlocked(int carIndex)
    {
        return CarsUnlocked[carIndex];
    }
}

public class Progress : MonoBehaviour
{
    public ProgressData Data;

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
        Data.Score += score;
        Save();
    }

    public void SaveBestScore(int bestScore)
    {
        Data.BestScore = bestScore;
        Save();
    }

    public void AddCoins(int value)
    {
        Data.Coins += value;
        Save();
    }

    public void UnlockCar(int carIndex)
    {
        Data.CarsUnlocked[carIndex] = true;
        Save();
    }

    private void Save()
    {
        ProgressData progressData = Data;

        string json = JsonUtility.ToJson(progressData);
        PlayerPrefs.SetString("Progress", json);
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey("Progress"))
        {
            string json = PlayerPrefs.GetString("Progress");
            Data = JsonUtility.FromJson<ProgressData>(json);
            Data.FillEmptyValues();
        } 
        else
        {
            Data = ProgressData.GetEmptyProgressData();
        }
        Save();
    }
}

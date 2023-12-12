using System;
using UnityEngine;

[System.Serializable]
public class ProgressData
{
    public bool[] CarsUnlockedDefault = { true, false, false, false, false, false };

    public int Score;
    public int Coins;
    public int BestScore;
    public int[] Health = {3, 4, 4, 4, 3, 3};
    public float[] Speed = {15f, 15.5f, 15.3f, 15.3f, 15.1f, 15f };

    public bool[] CarsUnlocked;

    public static ProgressData GetEmptyProgressData()
    {
        ProgressData data = new ProgressData();
        data.Health = new int[] { 3, 4, 4, 4, 3, 3 };
        data.Speed = new float[] { 15f, 15.5f, 15.3f, 15.3f, 15.1f, 15f };
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

    public void HealthUp(int carIndex)
    {
        Data.Health[carIndex] += 1;
        //Debug.Log(Data.Health[carIndex]);
        Save();
    }

    public void SpeedUp(int carIndex)
    {
        Data.Speed[carIndex] = Mathf.Round((Data.Speed[carIndex] + 0.1f) * 10.0f) * 0.1f;
        //Debug.Log(Data.Speed[carIndex]);
        Save();
    }

    public void SaveMoneyAfterPromo()
    {
        Save();
    }

    public int GetHealth(int carIndex)
    {
        return Data.Health[carIndex];
    }

    public float GetSpeed(int carIndex)
    {
        return Data.Speed[carIndex];
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

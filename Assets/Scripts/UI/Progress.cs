using System;
using UnityEngine;
using System.Runtime.InteropServices;

[System.Serializable]
public class ProgressData
{
    public bool[] CarsUnlockedDefault = { true, false, false, false, false, false };

    public int Score;
    public int Coins;
    public int BestScore;
    public int[] Health = {3, 5, 100, 6, 4, 5};
    public float[] Speed = {15f, 16f, 18f, 17.5f,15.4f, 16.6f };

    public bool[] CarsUnlocked;

    //[DllImport("__Internal")]
    //private static extern void SetLeaderBoard(int value);

    public static ProgressData GetEmptyProgressData()
    {
        ProgressData data = new ProgressData();
        data.Health = new int[] { 3, 5, 100, 6, 4, 5 };
        data.Speed = new float[] {15f, 16f, 18f, 17.5f,15.4f, 16.6f };
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
        //SetLeaderBoard(bestScore);
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

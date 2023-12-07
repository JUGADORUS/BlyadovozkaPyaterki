using UnityEngine;

[System.Serializable]
public class CarDataEntry
{
    public CarType CarType;
    public GameObject CarPrefab;
    public int Cost;
    public float Speed;
    public int Health;
}

[CreateAssetMenu]
public class CarData : ScriptableObject
{
    public CarDataEntry[] entries;

    public CarDataEntry GetCarData(CarType CarType)
    {
        for (int i = 0; i < entries.Length; i++)
        {
            if (entries[i].CarType == CarType)
            {
                return entries[i];
            }
        }
        return null;
    }
}



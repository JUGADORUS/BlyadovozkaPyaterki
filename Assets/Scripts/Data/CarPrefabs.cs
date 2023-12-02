using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CarData
{
    public CarType CarType;
    public GameObject _carPrefab;
}

[CreateAssetMenu]
public class CarPrefabs : ScriptableObject
{
    public CarData[] CarDatas;

    public GameObject GetCarPrefab(CarType CarType)
    {
        for (int i = 0; i < CarDatas.Length; i++)
        {
            if (CarDatas[i].CarType == CarType)
            {
                return CarDatas[i]._carPrefab;
            }
        }
        return null;
    }
}



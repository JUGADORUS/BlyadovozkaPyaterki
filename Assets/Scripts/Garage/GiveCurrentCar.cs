using UnityEngine;

public class GiveCurrentCar : MonoBehaviour
{
    public int GetIndexOfCurrentCar()
    {
        int indexOfCurrentCar = StaticData.valueToKeep;
        return indexOfCurrentCar;
    }
}

using UnityEngine;

public enum CarType
{
    Rafik = 0, 
    NissanGTR = 1,
    Taycan = 2,
    Gelik = 4,
    Cybertrack = 5
}

public class Car : MonoBehaviour
{
    [SerializeField] protected GiveCurrentCar indexOfCurrentCar;
    public CarType CarType;
}

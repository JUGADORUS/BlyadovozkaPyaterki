using UnityEngine;
using TMPro;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private TMP_Text costText;
    [SerializeField] private CarData carData;

    private int _cost;
    private int _carIndex;

    public static BuyButton Instance;

    public void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Start()
    {
        UpdateCost(0);
    }

    public void UpdateCost(CarType carType)
    {
        _cost = carData.GetCarData(carType).Cost;
        costText.SetText(_cost.ToString());
        _carIndex = (int) carType;
    }

    public void BuyCar()
    {
        if (Progress.Instance.Data.Coins >= _cost)
        {
            Progress.Instance.Data.Coins -= _cost;
            Progress.Instance.UnlockCar(_carIndex);
        }
        Podium.Instance.UpdateButtons();
        CoinCounter.Instance.UpdateCounter();
    }
}

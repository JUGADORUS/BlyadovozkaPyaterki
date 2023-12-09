using UnityEngine;
using TMPro;

public class ImproveSpeed : MonoBehaviour
{
    [SerializeField] private CarData carData;
    [SerializeField] private TMP_Text _speedText;
    [SerializeField] public TMP_Text _maxSpeed;

    private int _carIndex;
    private float _speed;

    public static ImproveSpeed Instance;

    public void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Start()
    {
        _maxSpeed.gameObject.SetActive(false);
        UpdateSpeedCharacteristics(0);
    }

    public void ImproveSpeedCharacteristics()
    {
        if (Progress.Instance.Data.Coins >= 5)
        {
            if (_speed < 23f)
            {
                Progress.Instance.Data.Coins -= 5;
                Progress.Instance.SpeedUp(_carIndex);
                Podium.Instance.UpdateButtons();
                CoinCounter.Instance.UpdateCounter();
                _speedText.SetText(_speed.ToString());
                PlayerCar.Instance._speed = _speed;
            }
            else
            {
                _maxSpeed.gameObject.SetActive(true);
            }
        }
        Debug.Log(_speed);
    }

    public void UpdateSpeedCharacteristics(CarType carType)
    {
        _speed = Progress.Instance.GetSpeed((int)carType);
        _speedText.SetText(_speed.ToString());
        _carIndex = (int)carType;
    }
}

using UnityEngine;
using TMPro;

public class ImproveHealth : MonoBehaviour
{
    [SerializeField] private CarData carData;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] public TMP_Text _maxHealth;

    private int _carIndex;
    private float _health;

    public static ImproveHealth Instance;

    public void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Start()
    {
        _maxHealth.gameObject.SetActive(false);
        UpdateHealthCharacteristics(0);
    }

    public void ImproveHealthCharacteristics() //это в кнопке
    {
        if (Progress.Instance.Data.Coins >= 10)
        {
            if (_health < 10f)
            {
                Progress.Instance.Data.Coins -= 10;
                Progress.Instance.HealthUp(_carIndex);
                Podium.Instance.UpdateButtons();
                CoinCounter.Instance.UpdateCounter();
                _healthText.SetText(_health.ToString());
            }
            else
            {
                _maxHealth.gameObject.SetActive(true);
            }
        }
    }

    public void UpdateHealthCharacteristics(CarType carType)
    {
        _health = Progress.Instance.GetHealth((int)carType);
        _healthText.SetText(_health.ToString());
        _carIndex = (int)carType;
    }
}

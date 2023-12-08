using UnityEngine;
using TMPro;

public class ImproveHealth : MonoBehaviour
{
    [SerializeField] private CarData carData;
    [SerializeField] private TMP_Text _healthText;

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
        UpdateHealthCharacteristics(0);
    }

    public void ImproveHealthCharacteristics()
    {
        Progress.Instance.HealthUp(_carIndex);
        Podium.Instance.UpdateButtons();
        CoinCounter.Instance.UpdateCounter();
        _healthText.SetText(_health.ToString());
    }

    public void UpdateHealthCharacteristics(CarType carType)
    {
        _health = Progress.Instance.GetHealth((int)carType);
        _healthText.SetText(_health.ToString());
        _carIndex = (int)carType;
    }
}

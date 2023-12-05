using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Health _healthPrefab;
    [SerializeField] private float _mapSize;

    [SerializeField] private float timerMinHealth;
    [SerializeField] private float timerMaxHealth;

    public static HealthManager Instance;

    private float time;
    private int _activeHealth = 0;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            if (_activeHealth < 10)
            {
                if (MenuManager.GameActive == true)
                {
                    //Хилки
                    float waitHealth = Random.Range(timerMinHealth, timerMaxHealth);
                    yield return new WaitForSeconds(waitHealth);
                    Vector3 healthPosition = GeneratePosition();
                    while (Physics.CheckSphere(healthPosition, 0.75f)) healthPosition = GeneratePosition();
                    Instantiate(_healthPrefab, healthPosition, Quaternion.identity);
                }
            }
            yield return null;
        }
    }

    private Vector3 GeneratePosition()
    {
        return new Vector3(Random.Range(-_mapSize, _mapSize), 1.5f, Random.Range(-_mapSize, _mapSize));
    }

    public void CollectHealth()
    {
        _activeHealth--;
        PlayerCar.Instance.Health++;
        CoinManager.Instance.amountHP.text = PlayerCar.Instance.Health.ToString();
    }
}

using System.Collections;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private float _mapSize;

    private int _activeCoins = 0;

    [SerializeField] private float timerMin;
    [SerializeField] private float timerMax;
    [SerializeField] private TMP_Text amountCoins;

    public static CoinManager Instance;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(SpawnCoins());
        amountCoins.text = Progress.Instance.Coins.ToString();
    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            if (_activeCoins < 10)
            {
                float wait = Random.Range(timerMin, timerMax);
                yield return new WaitForSeconds(wait);
                Vector3 position = GeneratePosition();
                while (Physics.CheckSphere(position, 0.75f)) position = GeneratePosition();
                Instantiate(_coinPrefab, position, Quaternion.identity);
                _activeCoins++;
            }
            yield return null;
        }
    }

    private Vector3 GeneratePosition()
    {
        return new Vector3(Random.Range(-_mapSize, _mapSize), 1.5f, Random.Range(-_mapSize, _mapSize));
    }

    public void CollectCoin()
    {
        _activeCoins--;
        Progress.Instance.AddCoins(1);
        amountCoins.text = Progress.Instance.Coins.ToString();
    }
}

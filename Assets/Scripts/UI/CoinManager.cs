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
    [SerializeField] private TMP_Text amountScore;
    [SerializeField] private TMP_Text bestScore;
    [SerializeField] public TMP_Text amountHP;

    public static CoinManager Instance;

    private float time;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(SpawnCoins());
        amountCoins.text = Progress.Instance.Data.Coins.ToString();
        amountScore.text = Progress.Instance.Data.Score.ToString();
        amountHP.text = PlayerCar.Instance.Health.ToString();
        bestScore.text = "Лучший: " + Progress.Instance.Data.BestScore.ToString();
    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            if (_activeCoins < 10)
            {
                if (MenuManager.GameActive == true)
                {
                    float wait = Random.Range(timerMin, timerMax);
                    yield return new WaitForSeconds(wait);
                    Vector3 position = GeneratePosition();
                    while (Physics.CheckSphere(position, 0.75f)) position = GeneratePosition();
                    Instantiate(_coinPrefab, position, Quaternion.identity);
                    _activeCoins++;
                }
            }
            yield return null;
        }
    }

    private Vector3 GeneratePosition()
    {
        return new Vector3(Random.Range(-_mapSize, _mapSize), 1.5f, Random.Range(-_mapSize, _mapSize));
    }

    private void Update()
    {

        if (MenuManager.GameActive == true)
        {
            time += Time.deltaTime;

            if (time > 1)
            {
                Progress.Instance.AddScore(1);
                amountScore.text = Progress.Instance.Data.Score.ToString();
                time = 0;

                if (Progress.Instance.Data.BestScore < Progress.Instance.Data.Score)
                {
                    Progress.Instance.Data.BestScore = Progress.Instance.Data.Score;
                    Progress.Instance.SaveBestScore(Progress.Instance.Data.BestScore);
                    bestScore.text = "Лучший: " + Progress.Instance.Data.BestScore.ToString();
                }
            }
        }

        else
        {
            if(Progress.Instance.Data.BestScore < Progress.Instance.Data.Score)
            {
                Progress.Instance.Data.BestScore = Progress.Instance.Data.Score;
                Progress.Instance.SaveBestScore(Progress.Instance.Data.BestScore);
                bestScore.text = Progress.Instance.Data.BestScore.ToString();
            }
            Progress.Instance.Data.Score = 0;
            amountScore.text = Progress.Instance.Data.Score.ToString();
        }
    }

    public void CollectCoin()
    {
        _activeCoins--;
        Progress.Instance.AddCoins(1);
        amountCoins.text = Progress.Instance.Data.Coins.ToString();
    }
}

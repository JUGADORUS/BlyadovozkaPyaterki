using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject CoinCollectEffect;
    public void Collect()
    {
        CoinManager.Instance.CollectCoin();
        Instantiate(CoinCollectEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Update()
    {
        transform.Rotate(0, 180 * Time.deltaTime, 0);
    }
}

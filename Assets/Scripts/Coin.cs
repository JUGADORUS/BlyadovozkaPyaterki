using UnityEngine;

public class Coin : MonoBehaviour
{
    public void Collect()
    {
        CoinManager.Instance.CollectCoin();
        Destroy(gameObject);
    }
}

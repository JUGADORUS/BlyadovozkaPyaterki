using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject HealthCollectEffect;
    public void Collect()
    {
        if (PlayerCar.Instance.Health <= PlayerCar.Instance.maxHealth)
        {
            HealthManager.Instance.CollectHealth();
        }

        Instantiate(HealthCollectEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Update()
    {
        transform.Rotate(0, 180 * Time.deltaTime, 0);
    }
}

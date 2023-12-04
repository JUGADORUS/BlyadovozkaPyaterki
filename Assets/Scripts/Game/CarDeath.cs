using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDeath : MonoBehaviour
{
    public static int Health = 3;
    [SerializeField] private GameObject _dieEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<UnbreakableObject>())
        {
            Die();
        }

        if (collision.gameObject.GetComponent<BreakableObject>())
        {
            if (gameObject.GetComponent<PlayerCar>())
            {
                PlayerCar.Instance.Health--;
                CoinManager.Instance.amountHP.text = PlayerCar.Instance.Health.ToString();

                if (PlayerCar.Instance.Health <= 0)
                {
                    Die();
                }
            }
            else
            {
                Health--;

                if (Health <= 0)
                {
                    Die();
                }
            }
        }

        if (collision.gameObject.GetComponent<Police>())
        {
            if (gameObject.GetComponent<PlayerCar>())
            {
                PlayerCar.Instance.Health--;
                CoinManager.Instance.amountHP.text = PlayerCar.Instance.Health.ToString();

                if (PlayerCar.Instance.Health <= 0)
                {
                    Die();
                }
            }
            else
            {
                Health--;

                if (Health <= 0)
                {
                    Die();
                }
            }
        }

        if (collision.gameObject.GetComponent<PlayerCar>())
        {
            Die();
        }
    }

    private void Die()
    {
        if (gameObject.GetComponent<PlayerCar>())
        {
            Instantiate(_dieEffect, transform.position, Quaternion.identity);
            StartCoroutine(GoBack());
            return;
        }

        Destroy(gameObject);
        Instantiate(_dieEffect, transform.position, Quaternion.identity);
    }

    IEnumerator GoBack()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        PlayerCar.Instance.transform.localScale = Vector3.zero;
        yield return new WaitForSeconds(2);
        GetComponent<Rigidbody>().isKinematic = false;
        PlayerCar.Instance.transform.localScale = Vector3.one;

        PlayerCar.Instance._carRotation = 0;
        PlayerCar.Instance._visualRotation = 0;
        PlayerCar.Instance.Health = 3;

        Health = 3;
        CoinManager.Instance.amountHP.text = PlayerCar.Instance.Health.ToString();

        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = MenuManager.Instance.transform.position;
        transform.rotation = MenuManager.Instance.transform.rotation;

        MenuManager.Instance.TurnOnMenu();
    }
}

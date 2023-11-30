using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDeath : MonoBehaviour
{
    public int Health = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<UnbreakableObject>())
        {
            Die();
        }

        if (collision.gameObject.GetComponent<BreakableObject>())
        {
            Health--;

            if(Health <= 0)
            {
               Die();
            }
        }

        if (collision.gameObject.GetComponent<Police>())
        {
            Health--;

            if (Health <= 0)
            {
                Die();
            }
        }

        if (collision.gameObject.GetComponent<Car>())
        {
            Die();
        }
    }

    private void Die()
    {
        if (gameObject.GetComponent<Car>())
        {
            Car.Instance._carRotation = 0;
            Car.Instance._visualRotation = 0;

            MenuManager.Instance.TurnOnMenu();
            Health = 3;

            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = MenuManager.Instance.transform.position;
            transform.rotation = MenuManager.Instance.transform.rotation;
            return;
        }
        Destroy(gameObject);
    }
}

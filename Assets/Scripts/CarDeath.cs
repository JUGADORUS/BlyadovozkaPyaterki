using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDeath : Car
{
    [SerializeField] Car car;
    public int Health = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<UnbreakableObject>())
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.GetComponent<BreakableObject>())
        {
            Health--;

            if(Health <= 0)
            {
               Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    [SerializeField] private Police PoliceCar;
    float time = 0;
    public static float minTime = 10f;
    public static float maxTime = 12f;

    private void FixedUpdate()
    {
        if (MenuManager.GameActive == true)
        {
            time += Time.deltaTime;

            if (time > Random.Range(minTime, maxTime))
            {
                Instantiate(PoliceCar, transform.position, Quaternion.identity);
                time = 0f;
            }
        }
    }
}

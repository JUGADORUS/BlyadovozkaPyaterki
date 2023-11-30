using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSpawner : MonoBehaviour
{
    [SerializeField] private Police PoliceCar;
    float time = 0;

    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if(time > 10f)
        {
            Instantiate(PoliceCar, transform.position, Quaternion.identity);
            time = 0f;
        }    
    }
}

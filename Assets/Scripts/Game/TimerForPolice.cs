using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerForPolice : MonoBehaviour
{
    private float timer = 0;

    private float FirstSpeed = 16.3f;
    private float SecondSpeed = 16.6f;
    private float ThirdSpeed = 16.9f;
    private float FourthSpeed = 17.2f;
    private float FifthSpeed = 18f;

    private void FixedUpdate()
    {
        if (MenuManager.GameActive == true)
        {
            timer += Time.deltaTime;
            if (timer > 30 && timer < 31)
            {
                Debug.Log("newSpeed");
                Police.speed = FirstSpeed;
                PoliceSpawner.minTime = 9f;
                PoliceSpawner.maxTime = 11f;
            }
            if (timer > 50 && timer < 51)
            {
                Debug.Log("newSpeed");
                Police.speed = SecondSpeed;
                PoliceSpawner.minTime = 7f;
                PoliceSpawner.maxTime = 9f;
            }
            if (timer > 80 && timer < 81)
            {
                Debug.Log("newSpeed");
                Police.speed = ThirdSpeed;
                PoliceSpawner.minTime = 6f;
                PoliceSpawner.maxTime = 8f;
            }
            if (timer > 110 && timer < 111)
            {
                Debug.Log("newSpeed");
                Police.speed = FourthSpeed;
                PoliceSpawner.minTime = 4f;
                PoliceSpawner.maxTime = 6f;
            }
            if (timer > 111)
            {
                Police.speed = FifthSpeed;
            }
        }
    }
}
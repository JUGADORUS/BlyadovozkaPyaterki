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

    private void FixedUpdate()
    {
        if (MenuManager.GameActive == true)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer > 30 && timer < 32)
            {
                Debug.Log("newSpeed");
                Police.Instance.speed = FirstSpeed;
            }
            if (timer > 50 && timer < 52)
            {
                Debug.Log("newSpeed");
                Police.Instance.speed = SecondSpeed;
            }
            if (timer > 80 && timer < 82)
            {
                Debug.Log("newSpeed");
                Police.Instance.speed = ThirdSpeed;
            }
            if (timer > 110 && timer < 112)
            {
                Debug.Log("newSpeed");
                Police.Instance.speed = FourthSpeed;
            }
        }
    }
}
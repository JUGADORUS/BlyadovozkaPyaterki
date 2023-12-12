using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerForAdv : MonoBehaviour
{
    public static float timeInGame = 0;
    
    public void FixedUpdate()
    {
        timeInGame += 1;
    }
}

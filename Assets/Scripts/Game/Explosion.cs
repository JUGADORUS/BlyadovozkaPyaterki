using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(ScheduleDestroy());
    }

    IEnumerator ScheduleDestroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}

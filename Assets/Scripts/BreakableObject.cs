using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    private List<GameObject> breakableObjects = new List<GameObject> { };

    public static BreakableObject Instance;

    private void OnCollisionEnter(Collision collision)
    {
        breakableObjects.Add(gameObject);
        gameObject.SetActive(false);
    }

    public void TurnOnBreakableObjects()
    {
        for (int i = 0; i < breakableObjects.Count; i++)
        {
            breakableObjects[i].SetActive(true);
        }
    }

}

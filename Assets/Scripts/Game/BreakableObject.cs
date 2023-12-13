using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        BreakableObjectManager.Instance.breakableObjects.Add(gameObject);
        gameObject.SetActive(false);
    } 
}
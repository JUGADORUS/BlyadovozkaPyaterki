using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceChase : MonoBehaviour
{
    [SerializeField] private float speed = 16;
    [SerializeField] private float rotatingSpeed = 8;

    private GameObject target;
    private Rigidbody policeCar;

    private void Start()
    {
        policeCar = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        Vector3 pointTarget = transform.position - target.transform.position;
        pointTarget.Normalize();

        float value = Vector3.Cross(pointTarget, transform.forward).y;

        policeCar.angularVelocity = rotatingSpeed * value * new Vector3(0, 1, 0);
        policeCar.velocity = transform.forward * speed;
    }
}

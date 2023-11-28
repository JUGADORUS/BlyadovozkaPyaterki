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

        if (target == null)
        {
            target = Car.Instance.gameObject;
            return;
        }
    }

    private void Awake()
    {
        policeCar = GetComponent<Rigidbody>();

        if (target == null)
        {
            target = Car.Instance.gameObject;
            return;
        }
    }

    private void FixedUpdate()
    {
        Vector3 pointTarget = transform.position - target.transform.position;
        pointTarget.Normalize();

        float value = Vector3.Cross(pointTarget, transform.forward).y;

        policeCar.angularVelocity = rotatingSpeed * value * new Vector3(0, 1, 0);
        policeCar.velocity = transform.forward * speed;
        Debug.Log(policeCar.angularVelocity);
        //Debug.Log(target);
    }
}

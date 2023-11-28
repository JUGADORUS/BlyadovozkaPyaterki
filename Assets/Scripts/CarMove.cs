using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : Car
{
    [SerializeField] private Transform _visualTransform;
    [SerializeField] private Transform _carTransform;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _sensetivity = 1f;
    [SerializeField] private float _visualSensetivity = 1f;
    [SerializeField] private Rigidbody _carRigidbody;
    [SerializeField] private float timeRotating = 1f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 forwardSpeed;

        forwardSpeed = transform.forward * _speed;
        _carRigidbody.velocity = forwardSpeed;

        if (Input.GetKey(KeyCode.A))
        {
            _visualTransform.localEulerAngles += new Vector3(0, (-1f * _visualSensetivity), 0);
            _carTransform.localEulerAngles += new Vector3(0, -1f * _sensetivity, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _visualTransform.localEulerAngles += new Vector3(0, (1f * _visualSensetivity), 0);
            _carTransform.localEulerAngles += new Vector3(0, 1f * _sensetivity, 0);
        }

        //else
        //{
        //    StartCoroutine(CarVisualRotateToDefaultProcess());
        //}
    }

    private IEnumerator CarVisualRotateToDefaultProcess()
    {
        Vector3 startRotation = _visualTransform.transform.rotation.eulerAngles;

        for (float t = 0; t < 1f; t += Time.deltaTime / timeRotating)
        {
            float rotation = Mathf.Lerp(_visualTransform.rotation.y, 0f, 10);
            _visualTransform.localEulerAngles = new Vector3(0, rotation, 0);
            //_visualTransform.transform.up. = Vector3.Lerp(startRotation, Vector3.zero, t);
            yield return null;
        }
    }
}

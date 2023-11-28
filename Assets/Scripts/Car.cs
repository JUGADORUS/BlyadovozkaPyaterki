using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Transform _carTransform;
    [SerializeField] private Transform _visualTransform;
    [SerializeField] private Rigidbody _carRigidbody;

    private float _speed = 15f;

    [SerializeField] private float _deltaCarRotation = 90f;
    [SerializeField] private float _deltaVisualRotation = 45f;

    private float _carRotation = 0f;
    private float _visualRotation = 0f;

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
        _carTransform.localEulerAngles = new Vector3(0, _carRotation, 0);
        _visualTransform.localEulerAngles = new Vector3(0, _visualRotation, 0);

        if (Input.GetKey(KeyCode.A))
        {
            if(_visualRotation > 0)
            {
                _visualRotation *= 0.65f;
            }

            _carRotation -= _deltaCarRotation * Time.deltaTime;
            _visualRotation -= _deltaVisualRotation * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (_visualRotation < 0)
            {
                _visualRotation *= 0.65f;
            }

            _carRotation += _deltaCarRotation * Time.deltaTime;
            _visualRotation += _deltaVisualRotation * Time.deltaTime;
        }
        else
        {
            _visualRotation *= 0.95f;
        }
        _visualRotation = Mathf.Clamp(_visualRotation, -60f, 60f);
    }
}

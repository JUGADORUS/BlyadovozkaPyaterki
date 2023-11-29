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

    public static Car Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (MenuManager.GameActive == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {
        Debug.Log(_carRigidbody.velocity);
        //реяр
        //Debug.Log(_carRigidbody.velocity);
        //if (_carRigidbody.velocity == Vector3.zero)
        //{
        //    Debug.Log("рш кну");
        //    _carTransform.localEulerAngles = new Vector3(0, 0, 0);
        //    _visualTransform.localEulerAngles = new Vector3(0, 0, 0);
        //}
        //реяр

        if (MenuManager.GameActive == true)
        {
            Vector3 forwardSpeed;

            forwardSpeed = transform.forward * _speed;
            _carRigidbody.velocity = forwardSpeed;
            _carTransform.localEulerAngles = new Vector3(0, _carRotation, 0);
            _visualTransform.localEulerAngles = new Vector3(0, _visualRotation, 0);

            if (Input.GetKey(KeyCode.A))
            {
                if (_visualRotation > 0)
                {
                    _visualRotation *= 0.99f;
                }

                _carRotation -= _deltaCarRotation * Time.deltaTime;
                _visualRotation -= _deltaVisualRotation * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (_visualRotation < 0)
                {
                    _visualRotation *= 0.99f;
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
}

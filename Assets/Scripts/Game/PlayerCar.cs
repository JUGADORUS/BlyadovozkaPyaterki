using Unity.VisualScripting;
using UnityEngine;

public class PlayerCar : Car
{
    [SerializeField] private Transform _carTransform;
    [SerializeField] private Transform _visualTransform;
    [SerializeField] private Rigidbody _carRigidbody;
    [SerializeField] private CarData _carPrefabs;
    [SerializeField] private Transform _visualParent;
    

    private float _speed = 15f;

    [SerializeField] private float _deltaCarRotation = 115f;
    [SerializeField] private float _deltaVisualRotation = 35f;

    [SerializeField] private ParticleSystem _leftSmoke;
    [SerializeField] private ParticleSystem _rightSmoke;
    private TrailRenderer _leftTrail;
    private TrailRenderer _rightTrail;

    public float _carRotation = 0f;
    public float _visualRotation = 0f;
    public int Health = 3;

    public static PlayerCar Instance;

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
        _leftTrail = _leftSmoke.gameObject.GetComponent<TrailRenderer>();
        _rightTrail = _rightSmoke.gameObject.GetComponent<TrailRenderer>();
    }

    public int CoinsCollected = 0;

    private void Start()
    {
        if (MenuManager.GameActive == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        SetupCurrentCar(indexOfCurrentCar.GetIndexOfCurrentCar());
    }

    void Update()
    {
        if (MenuManager.GameActive == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (_visualRotation > 0) _visualRotation *= 0.99f;
                _carRotation -= _deltaCarRotation * Time.deltaTime;
                _visualRotation -= _deltaVisualRotation * Time.deltaTime;

                if (_visualRotation < -30)
                {
                    _leftTrail.emitting = true;
                    _rightTrail.emitting = true;
                     _leftSmoke.Play();
                     _rightSmoke.Play();
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (_visualRotation < 0) _visualRotation *= 0.99f;
                _carRotation += _deltaCarRotation * Time.deltaTime;
                _visualRotation += _deltaVisualRotation * Time.deltaTime;
                
                if (_visualRotation > 30)
                {
                    _leftTrail.emitting = true;
                    _rightTrail.emitting = true;
                     _leftSmoke.Play();
                     _rightSmoke.Play();
                }
            }
            else
            {
                _visualRotation *= 0.95f;
                _leftSmoke.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                _rightSmoke.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                _leftTrail.emitting = false;
                _rightTrail.emitting = false;
            }
            _visualRotation = Mathf.Clamp(_visualRotation, -60f, 60f);

            Vector3 speed;

            speed = transform.forward * _speed;
            _carRigidbody.velocity = speed;
            _carTransform.localEulerAngles = new Vector3(0, _carRotation, 0);
            _visualTransform.localEulerAngles = new Vector3(0, _visualRotation, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Coin>() is Coin coin)
        {
            coin.Collect();
            CoinsCollected += 1;
        }
        if (other.gameObject.GetComponent<Health>() is Health health)
        {
            health.Collect();
        }
    }
    private void SetupCurrentCar(int Index)
    {
        GameObject currentCar = _carPrefabs.GetCarData((CarType)Index).CarPrefab;
        Instantiate(currentCar, _visualParent);
    }

}

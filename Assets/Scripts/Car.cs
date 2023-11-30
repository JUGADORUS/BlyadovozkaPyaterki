using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Transform _carTransform;
    [SerializeField] private Transform _visualTransform;
    [SerializeField] private Rigidbody _carRigidbody;

    private float _speed = 15f;

    [SerializeField] private float _deltaCarRotation = 90f;
    [SerializeField] private float _deltaVisualRotation = 45f;

    public float _carRotation = 0f; //ÏÎÌÅÍßË ÍÀ ÏÀÁËÈÊ
    public float _visualRotation = 0f;

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

    public int CoinsCollected = 0;

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

        if (MenuManager.GameActive == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (_visualRotation > 0) _visualRotation *= 0.99f;
                _carRotation -= _deltaCarRotation * Time.deltaTime;
                _visualRotation -= _deltaVisualRotation * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (_visualRotation < 0) _visualRotation *= 0.99f;
                _carRotation += _deltaCarRotation * Time.deltaTime;
                _visualRotation += _deltaVisualRotation * Time.deltaTime;
            }
            else
            {
                _visualRotation *= 0.95f;
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
    }
}

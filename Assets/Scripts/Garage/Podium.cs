using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Podium : MonoBehaviour
{
    private float _rotationAmount = 60f;
    private float _currentRotation = 0f;
    public int _currentIndex = 0;

    [SerializeField] private Transform _podium;
    [SerializeField] private AnimationCurve _rotationCurve;
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;
    [SerializeField] private Button _confirm;

    public static Podium Instance;

    public void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Start()
    {
        bool isUnlocked = Progress.Instance.Data.IsCarUnlocked(_currentIndex);
        _confirm.gameObject.SetActive(isUnlocked);
        BuyButton.Instance.gameObject.SetActive(!isUnlocked);
    }

    public void RotateCircleToLeft()
    {
        _currentIndex--;
        if (_currentIndex < 0) _currentIndex = 5;
        StartCoroutine(RotationCircle(-_rotationAmount));
        _leftButton.interactable = false;
        _rightButton.interactable = false;
        BuyButton.Instance.UpdateCost((CarType) _currentIndex);
    }

    public void RotateCircleToRight()
    {
        _currentIndex++;
        if (_currentIndex > 5) _currentIndex = 0;
        StartCoroutine(RotationCircle(_rotationAmount));
        _rightButton.interactable = false;
        _leftButton.interactable = false;
        BuyButton.Instance.UpdateCost((CarType)_currentIndex);
    }

    private IEnumerator RotationCircle(float rotationAmount)
    {
        UpdateButtons();
        for (float i = 0f; i <= 1f; i += Time.deltaTime)
        {
            float t;
            t = _rotationCurve.Evaluate(i);
            float newRotation = Mathf.Lerp(_currentRotation, _currentRotation + rotationAmount, t);
            _podium.transform.rotation = Quaternion.Euler(0, newRotation, 0);
            yield return null;
        }
        _currentRotation += rotationAmount;
        _leftButton.interactable = true;
        _rightButton.interactable = true;
    }

    public void UpdateButtons()
    {
        bool isUnlocked = false;
        if (Progress.Instance.Data.IsCarUnlocked(_currentIndex))
        {
            isUnlocked = Progress.Instance.Data.IsCarUnlocked(_currentIndex);
        }
        
        _confirm.gameObject.SetActive(isUnlocked);
        BuyButton.Instance.gameObject.SetActive(!isUnlocked);
    }
}



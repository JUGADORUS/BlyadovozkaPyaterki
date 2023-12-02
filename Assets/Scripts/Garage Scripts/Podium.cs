using System.Collections;
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


    //Метод кнопки влево
    public void RotateCircleToLeft()
    {
        StartCoroutine(RotationCircle(-_rotationAmount));
        Debug.Log("Left arrow");
        _leftButton.interactable = false;
        _rightButton.interactable = false;
        _currentIndex--;
        if (_currentIndex < 0)
        {
            _currentIndex = 5;
        }

    }

    //Метод кнопки вправо
    public void RotateCircleToRight()
    {
        StartCoroutine(RotationCircle(_rotationAmount));
        Debug.Log("Right arrow");
        _rightButton.interactable = false;
        _leftButton.interactable = false;
        _currentIndex++;
        if (_currentIndex > 5)
        {
            _currentIndex = 0;
        }

    }
    //Корутина прокрутки
    private IEnumerator RotationCircle(float rotationAmount)
    {

        for (float i = 0f; i <= 1f; i += Time.deltaTime)
        {
            float t;
            t = _rotationCurve.Evaluate(i);
            float newRotation = Mathf.Lerp(_currentRotation, _currentRotation + rotationAmount, t);
            _podium.transform.rotation = Quaternion.Euler(0, newRotation, 0);
            yield return null;
        }
        Debug.Log(_currentIndex);
        _currentRotation += rotationAmount;
        _leftButton.interactable = true;
        _rightButton.interactable = true;
    }
}



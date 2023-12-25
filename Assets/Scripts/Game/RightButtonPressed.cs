using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonPressed;

    public static RightButtonPressed Instance;

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

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
        Debug.Log("ayy");
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }
}

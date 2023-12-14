using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsHowToControl : MonoBehaviour
{
    [SerializeField] private GameObject ADButton;

    public static TipsHowToControl Instance;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else Destroy(gameObject);
    }

    void Start()
    {
        ADButton.SetActive(false);
    }

    public void TurnOnTips()
    {
        ADButton.SetActive(true);
    }

    public void TurnOffTips()
    {
        ADButton.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayButton : MonoBehaviour
{
    [SerializeField] private GameObject _tips;
    [SerializeField] private GameObject _goBack;

    private void Start()
    {
        _goBack.SetActive(false);
        _tips.SetActive(false);
    }

    public void TurnOnTips()
    {
        _goBack.SetActive(true);
        _tips.SetActive(true);
    }

    public void TurnOffTips()
    {
        _goBack.SetActive(false);
        _tips.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsHowToControl : MonoBehaviour
{
    [SerializeField] private GameObject IngameTips;

    public static TipsHowToControl Instance;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else Destroy(gameObject);
    }

    void Start()
    {
        IngameTips.SetActive(false);
    }

    public void TurnOnTips()
    {
        IngameTips.SetActive(true);
    }

    public void TurnOffTips()
    {
        IngameTips.SetActive(false);
    }
}

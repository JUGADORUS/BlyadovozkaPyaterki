using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowAmountCoins : MonoBehaviour
{
    [SerializeField] private TMP_Text amountCoins;
    void Start()
    {
        amountCoins.text = Progress.Instance.Coins.ToString();
    }
}

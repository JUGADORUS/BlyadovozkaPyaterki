using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowAmountCoins : MonoBehaviour
{
    [SerializeField] private TMP_Text amountCoins;
    [SerializeField] private TMP_Text amountHP;
    void Start()
    {
        amountCoins.text = Progress.Instance.Coins.ToString();
        amountHP.text = PlayerCar.Instance.Health.ToString();
    }
}

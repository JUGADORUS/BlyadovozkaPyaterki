using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField] private GameObject ConfirmButton;
    [SerializeField] private GameObject BuyCarButton;
    // Start is called before the first frame update

    private void Start()
    {
        ConfirmButton.SetActive(false);
        BuyCarButton.SetActive(false);
    }

    public void TurnOnBuyCarButton()
    {
        BuyCarButton.SetActive(true);
    }

    public void TurnOnConfirmButton()
    {
        ConfirmButton.SetActive(true);
    }

    public void TurnOffBuyCarButton()
    {
        BuyCarButton.SetActive(false);
    }

    public void TurnOffConfirmButton()
    {
        ConfirmButton.SetActive(false);
    }
}

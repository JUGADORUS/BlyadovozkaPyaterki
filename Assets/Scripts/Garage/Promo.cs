using UnityEngine;
using TMPro;

public class Promo : MonoBehaviour
{
    [SerializeField] private TMP_InputField _InputField;
    [SerializeField] private string _promo;

    public void Ok()
    {
        if(_InputField.text == _promo)
        {
            Progress.Instance.Data.Coins += 1000;
            Podium.Instance.UpdateButtons();
            CoinCounter.Instance.UpdateCounter();
            Progress.Instance.SaveMoneyAfterPromo();
        }
    }
}

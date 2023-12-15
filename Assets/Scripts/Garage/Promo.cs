using UnityEngine;
using TMPro;

public class Promo : MonoBehaviour
{
    [SerializeField] private TMP_InputField _InputField;
    [SerializeField] private string _promo;

    public void Ok()
    {
        if (_InputField.text == _promo && BuildFlag.BuildValue == 69)
        {
            _InputField.text = " ";
            Progress.Instance.Data.Coins += 2000;
            Podium.Instance.UpdateButtons();
            CoinCounter.Instance.UpdateCounter();
            Progress.Instance.SaveMoneyAfterPromo();
            _promo = "dkfsjklfjweouifhsdjkfhuheuiyfwegfihwefweqwerty";
        }
    }
}

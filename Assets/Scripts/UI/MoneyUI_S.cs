using UnityEngine;
using TMPro;

public class MoneyUI_S : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    private void Update()
    {
        moneyText.text = "$" + PlayerStats_S.money.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyChanger : MonoBehaviour
{
    public Money money;
    private InputField inputField;

    public void Start() {
        inputField = this.gameObject.GetComponent<InputField>();
    }

    public void ChangeMoney() {
        float inputMoney = float.Parse(inputField.text);
        money.moneyAmount = inputMoney;
    }

    public void MoneyChanged(float newMoneyAmount) {
        inputField.text = newMoneyAmount.ToString();

    }
}

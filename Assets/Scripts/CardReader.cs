using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardReader : MonoBehaviour
{
    private Money money;
    private float needMoney = 0; //сколько нужно снять денег
    private bool isEnabled = false;
    public GameObject sound;
    public ShoppingController shoppingController;
    public InputField inputField;

    public IEnumerator OnTriggerEnter2D(Collider2D others) //срабатывает когда два коллайдераа соприкасаются.
    {
        if (isEnabled)
        {
            money = others.gameObject.GetComponent<Money>();

            if (money != null && money.moneyAmount >= needMoney) //если у объекта найден компонент Money и хватает денег
            {
                money.moneyAmount -= needMoney;
                inputField.SendMessage("MoneyChanged", money.moneyAmount);
                shoppingController.SendMessage("PaymentSucces", true);
                sound.SetActive(true);
                yield return new WaitForSeconds(3);
                sound.SetActive(false);
            }
            else
            {
                shoppingController.SendMessage("PaymentSucces", false);
            }
        }
    }

    public void Disable()
    {
        needMoney = 0;
        isEnabled = false;
    }

    public void Enable(float needMoney)
    {
        this.needMoney = needMoney;
        isEnabled = true;
    }
}

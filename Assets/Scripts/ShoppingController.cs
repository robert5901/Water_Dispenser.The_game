using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingController : MonoBehaviour
{
    public float cost1_5;
    public float cost2;
    public float cost3;
    public float cost5;
    public GameObject button1_5;
    public GameObject button2;
    public GameObject button3;
    public GameObject button5;
    public GameObject card;
    public GameObject selectText;
    public GameObject deniedText;
    public GameObject waitText;
    public GameObject paymentText;
    public GameObject doneText;
    public CardReader cardReader;
    public Vector3 spawnPosition;
    public BottleSpawner bottleSpawner;
    public GameObject buttonCancel;
    private int bottleType;
    private float chosenMoney; //сколько снимается с карты, после выбора литров

    void Start()
    {
        cardReader.SendMessage("Disable"); //при состоянии выбора литров cardReader выключен
    }


    public void OnButtonClick(GameObject button)
    {
        if (button.name == button1_5.name)
        {
            bottleType = 1;
            StartPayment(cost1_5);
        }
        if (button.name == button2.name)
        {
            bottleType = 2;
            StartPayment(cost2);
        }
        if (button.name == button3.name)
        {
            bottleType = 3;
            StartPayment(cost3);
        }
        if (button.name == button5.name)
        {
            bottleType = 4;
            StartPayment(cost5);
        }
        if (button.name == buttonCancel.name)
        {
            SetChoiseMode();
        }
    }

    public  void SetChoiseMode()
    {
        paymentText.SetActive(false);
        selectText.SetActive(true);
        Debug.Log("Возврат в состояние выбора");
        //включение кнопок выбора
        button1_5.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        button5.SetActive(true);
        buttonCancel.SetActive(false);
        cardReader.SendMessage("Disable");
    }

    public void StartPayment(float money)
    {
        card.SetActive(true);
        selectText.SetActive(false);
        paymentText.SetActive(true);
        //выключение кнопок выбора
        button1_5.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button5.SetActive(false);
        cardReader.SendMessage("Enable", money);
        //включение кнопки отмены
        buttonCancel.SetActive(true);
    }

    public IEnumerator PaymentSucces(bool isSucces) {
        cardReader.SendMessage("Disable");

        if (isSucces)
        {
            paymentText.SetActive(false);
            waitText.SetActive(true);
            Debug.Log("Оплата успешна");
            buttonCancel.SetActive(false);
            //подождать 3 сек перед спавном бутылки
            yield return new WaitForSeconds(3);
            waitText.SetActive(false);
            doneText.SetActive(true);
            Debug.Log("Спавн бутылки произошел");
            //спавн бутылки, в зависимости от выбранных литров
            bottleSpawner.SendMessage("BottleSpawn", bottleType);
            doneText.SetActive(false);
            selectText.SetActive(true);
            //включение кнопок выбора
            button1_5.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
            button5.SetActive(true);
        }
        else {
            paymentText.SetActive(false);
            deniedText.SetActive(true);
            Debug.Log("Оплата ГОВНО!");
            buttonCancel.SetActive(false);
            //подождать 3 сек
            yield return new WaitForSeconds(3);
            deniedText.SetActive(false);
            selectText.SetActive(true);
            Debug.Log("Возврат в состояние выбора");
            //включение кнопок выбора
            button1_5.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
            button5.SetActive(true);
        }
    }

    

    
    
}

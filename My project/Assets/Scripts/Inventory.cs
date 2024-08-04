using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // [HideInInspector]
    public int money;

    private Text moneyText;   
    // Start is called before the first frame update
    void Start()
    {
        money = 0;

        //I don't like finding UI that way but that seem the easiest option
        moneyText = GameObject.Find("MoneyText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddMoney(int moneyGain)
    {
        money += moneyGain;
        moneyText.text = "Money :" + money;
    }

    public void RemoveMoney(int moneyLoss)
    {
        money -= moneyLoss;

    }

}

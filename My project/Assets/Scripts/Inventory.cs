using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // [HideInInspector]
    public int money;
    // Start is called before the first frame update
    void Start()
    {money = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddMoney(int moneyGain)
    {money +=moneyGain;
        
    }
    
    public void RemoveMoney(int moneyLoss)
    {money -=moneyLoss;
        
    }
    
}

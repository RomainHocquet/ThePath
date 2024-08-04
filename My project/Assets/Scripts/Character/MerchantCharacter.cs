using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class MerchantCharacter : Character
{
    GameObject shopUI;
    GameObject OpenShopButtonUI;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        hexCell.isObstacle = true;
        shopUI = MainUI.ShopUI;
        OpenShopButtonUI = MainUI.OpenShopButtonUI;
        shopUI.SetActive(false);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    public override void Interact(Character characterInteracting)
    {

        shopUI.SetActive(true);
        OpenShopButtonUI.SetActive(false);
        //Open the shop
    }
    public override void EndTurn()
    {
        shopUI.SetActive(false);
        OpenShopButtonUI.SetActive(false);
    }

}

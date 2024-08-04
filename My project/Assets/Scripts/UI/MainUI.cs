using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{

    // Instance variables to be assigned via the Inspector
    [SerializeField] private GameObject openShopButtonUI;
    [SerializeField] private GameObject shopUI;

    [SerializeField] private GameObject openInventoryButtonUI;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject statsUI;


    // Static variables to be accessed globally
    public static GameObject OpenShopButtonUI { get; private set; }
    public static GameObject ShopUI { get; private set; }

    public static GameObject OpenInventoryButtonUI { get; private set; }
    public static GameObject InventoryUI { get; private set; }

    public static GameObject PlayerStatsUI { get; private set; }


    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Initialize static variables from instance variables
        UpdateStaticVariables();
    }

    // Method to update static variables
    public void UpdateStaticVariables()
    {
        OpenShopButtonUI = openShopButtonUI;
        ShopUI = shopUI;
        OpenInventoryButtonUI = openInventoryButtonUI;
        InventoryUI = inventoryUI;
        PlayerStatsUI = statsUI;
    }
}
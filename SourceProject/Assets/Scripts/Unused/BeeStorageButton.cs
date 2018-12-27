using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeStorageButton : MonoBehaviour {

    private CurrencyManager currencyManager;
    //private BeeStorageManager beeStorageManager;
    private MenuManagerStorage menuManager;
    private MenuHeader menuHeader;
    private Text costText;
    [Header ("Settings")]
    public float costAmount;
    public int storageAmount;
    public int buttonNumber;
    public int containerNumber;

    private void Start ()
    {
        //CAN I FIND LESS OBJECTS FOR IMPROVED PERFORMANCE?
        currencyManager = GameObject.Find("GameManager").GetComponent<CurrencyManager>();
        //beeStorageManager = GameObject.Find("BeeStorage").GetComponent<BeeStorageManager>();
        menuHeader = GameObject.Find("MenuHeader").GetComponent<MenuHeader>();
        menuManager = transform.GetComponentInParent<MenuManagerStorage>();
        costText = transform.Find("CostText").GetComponent<Text>();
        costText.text = costAmount.ToString();
    }


    public void Purchase()
    {
        if (currencyManager.scriptableCurrencyManager.totalCurrency >= costAmount)
        {
            currencyManager.RemoveCurrency(costAmount);
            //beeStorageManager.UpgradeStorage(storageAmount);
            //beeStorageManager.BeeContainer02(containerNumber);
            menuManager.RemoveButtons(buttonNumber);
            menuHeader.UpdateHeader(storageAmount);
        }
    }
}

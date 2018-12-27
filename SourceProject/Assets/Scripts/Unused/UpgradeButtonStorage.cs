using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonStorage : MonoBehaviour {

    private CurrencyManager currencyManager;
    //private BeeStorageManager storageManager;
    private Text costText;
    [Header("Settings")]
    public float costAmount;
    public float storageMultiplier;
    public float multiplierIncrease;

    private void Start ()
    {
        currencyManager = GameObject.Find("GameManager").GetComponent<CurrencyManager>();
        //storageManager = GameObject.Find("BeeStorage").GetComponent<BeeStorageManager>();
        costText = transform.Find("CostText").GetComponent<Text>();
    }


    private void Update()
    {
        costText.text = costAmount.ToString();
    }


    /*public void Purchase()
    {
        if (currencyManager.currency >= costAmount)
        {
            currencyManager.RemoveCurrency(costAmount);
            costAmount += costAmount * storageMultiplier;
        }
    }*/
}

//NOTES
//Different buttons might need different scripts
//Categorize button scripts by what the multiply - Honey Value, Bees per min, storage etc

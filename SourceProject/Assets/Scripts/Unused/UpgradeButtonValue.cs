using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonValue : MonoBehaviour {

    private CurrencyManager currencyManager;
    private Text costText;
    [Header("Settings")]
    public float costAmount;
    public float costMultiplier;
    public float multiplierIncrease;

    private void Start ()
    {
        currencyManager = GameObject.Find("GameManager").GetComponent<CurrencyManager>();
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
            costAmount += costAmount * costMultiplier;
            currencyManager.valueMultiplier += multiplierIncrease;
        }
    }*/
}

//NOTES
//Different buttons might need different scripts
//Categorize button scripts by what the multiply - Honey Value, Bees per min, storage etc
//This may result in button colors requiring multiple arrays? Is there a better way to do this?

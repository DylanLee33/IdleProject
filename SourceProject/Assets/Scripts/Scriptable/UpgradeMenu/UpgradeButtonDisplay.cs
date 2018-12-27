using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonDisplay : MonoBehaviour {

    public UpgradeButton upgradeButton;
    private CurrencyManager currencyManager;
    private NetManager netManager;

    private Text nameText;
    private Text researchText;
    private Text upgradeText;
    private Text costText;

    private Image buttonImage;
    public Sprite tempImage;
    private Button button;

    private void Start ()
    {
        currencyManager = CurrencyManager.currencyManagerInstance;
        netManager = NetManager.netManagerInstance;

        nameText = transform.Find("NameText").GetComponent<Text>();
        nameText.text = upgradeButton.nameText;

        researchText = transform.Find("ResearchText").GetComponent<Text>();
        researchText.text = upgradeButton.researchText;

        upgradeText = transform.Find("UpgradeText").GetComponent<Text>();
        upgradeText.text = upgradeButton.upgradeText;

        costText = transform.Find("CostText").GetComponent<Text>();
        costText.text = upgradeButton.costAmount.ToString("#.00");

        buttonImage = transform.Find("Button").GetComponent<Image>();
    }
	

	private void Update ()
    {
        //Change the image if button can no longer be upgraded, disable script
        if (upgradeButton.currentPurchaseAmount == upgradeButton.maxPurchaseAmount)
        {
            buttonImage.sprite = tempImage;
            this.enabled = false;
            return;
        }

        //Control the button colors
        if (upgradeButton.costAmount >= currencyManager.scriptableCurrencyManager.totalCurrency)
        {
            buttonImage.color = upgradeButton.normalColor;
        }
        else if (upgradeButton.costAmount < currencyManager.scriptableCurrencyManager.totalCurrency)
        {
            buttonImage.color = upgradeButton.purchasableColor;
        }
    }


    public void PurchaseValue()
    {
        if (currencyManager.scriptableCurrencyManager.totalCurrency >= upgradeButton.costAmount && upgradeButton.currentPurchaseAmount < upgradeButton.maxPurchaseAmount)
        {
            currencyManager.RemoveCurrency(upgradeButton.costAmount); //This could be done by simply subtracting the amount rather than a function, keep function incase more stuff is needed
            upgradeButton.costAmount = upgradeButton.costAmount * upgradeButton.costMultiplier;
            upgradeButton.currentPurchaseAmount++;
            costText.text = upgradeButton.costAmount.ToString("#.00");

            currencyManager.scriptableCurrencyManager.currencyMulti += upgradeButton.valueMultiplier;
        }
    }


    public void PurchaseNetCapacity()
    {
        if (currencyManager.scriptableCurrencyManager.totalCurrency >= upgradeButton.costAmount && upgradeButton.currentPurchaseAmount < upgradeButton.maxPurchaseAmount)
        {
            currencyManager.RemoveCurrency(upgradeButton.costAmount); //This could be done by simply subtracting the amount rather than a function, keep function incase more stuff is needed
            upgradeButton.costAmount = upgradeButton.costAmount * upgradeButton.costMultiplier;
            upgradeButton.currentPurchaseAmount++;
            costText.text = upgradeButton.costAmount.ToString("#.00");

            currencyManager.scriptableCurrencyManager.netCapacity += upgradeButton.netCapacity; //Currently adds a flat amount to nets fish per second
        }
    }


    public void PurchaseFishing() //Finish this one up later
    {
        if (currencyManager.scriptableCurrencyManager.totalCurrency >= upgradeButton.costAmount && upgradeButton.currentPurchaseAmount < upgradeButton.maxPurchaseAmount)
        {
            currencyManager.RemoveCurrency(upgradeButton.costAmount); //This could be done by simply subtracting the amount rather than a function, keep function incase more stuff is needed
            upgradeButton.costAmount = upgradeButton.costAmount * upgradeButton.costMultiplier;
            upgradeButton.currentPurchaseAmount++;
            costText.text = upgradeButton.costAmount.ToString("#.00");

            /*storageManager.scriptableStorageManager.storageMulti += upgradeButton.storageMulti;
            storageManager.ApplyStorageMulti();*/
        }
    }

    
    public void DefaultValues() //Reset the values of the scriptable button to their start values
    {
        upgradeButton.costAmount = upgradeButton.defaultCostAmount;
        upgradeButton.currentPurchaseAmount = upgradeButton.defaultCurrentPurchaseAmount;
    }
}

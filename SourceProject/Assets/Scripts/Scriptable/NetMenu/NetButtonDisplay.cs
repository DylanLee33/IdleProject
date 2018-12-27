using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetButtonDisplay : MonoBehaviour {

    public NetButton netButton;
    private CurrencyManager currencyManager;
    private NetManager netManager;
    private MenuManagerStorage menuManager;
    private MenuHeader menuHeader;
    private string scientificFormat = "#.000.e+0";

    private Text nameText;
    private Text researchText;
    private Text netText;
    private Text costText;

    private Image buttonImage;

    private void Start ()
    {
        currencyManager = CurrencyManager.currencyManagerInstance;
        netManager = NetManager.netManagerInstance;
        menuManager = transform.GetComponentInParent<MenuManagerStorage>();
        menuHeader = GameObject.Find("MenuHeader").GetComponent<MenuHeader>();

        nameText = transform.Find("NameText").GetComponent<Text>();
        researchText = transform.Find("ResearchText").GetComponent<Text>();
        netText = transform.Find("NetText").GetComponent<Text>();
        costText = transform.Find("CostText").GetComponent<Text>();

        nameText.text = netButton.nameText;
        researchText.text = netButton.researchText;
        netText.text = netButton.netText + netButton.costAmount.ToString(); //Might not need the string on the scriptable here

        if (netButton.scientificNotation) //Display numbers in scientific or suffixed based on boolean
        {
            costText.text = netButton.costAmount.ToString(scientificFormat);
        }
        else
        {
            costText.text = LargeNumber.ToString(netButton.costAmount);
        }

        buttonImage = transform.Find("Button").GetComponent<Image>();
    }


    private void Update()
    {
        //Control the button colors
        if (netButton.costAmount >= currencyManager.scriptableCurrencyManager.totalCurrency)
        {
            buttonImage.color = netButton.normalColor;
        }
        else if (netButton.costAmount < currencyManager.scriptableCurrencyManager.totalCurrency)
        {
            buttonImage.color = netButton.purchasableColor;
        }

        //Destroy buttons if they have been purchased
        if (netButton.hasPurchased == true)
        {
            Destroy(this.gameObject);
        }
    }


    public void Purchase()
    {
        if (currencyManager.scriptableCurrencyManager.totalCurrency >= netButton.costAmount)
        {
            currencyManager.RemoveCurrency(netButton.costAmount); //This could be done by simply subtracting the amount rather than a function, keep function incase more stuff is needed
            currencyManager.scriptableCurrencyManager.netCapacity = netButton.netCapacity;
            netManager.BeeContainer02(netButton.containerInt);
            menuManager.RemoveButtons(netButton.menuInt);
            menuHeader.UpdateHeader(netButton.netCapacity);

            //storageManager.ApplyStorageMulti(); //Storage amount, old system
            //storageManager.UpgradeStorage(storageButton.netCapacity); //Storage amount, old system
        }
    }
}

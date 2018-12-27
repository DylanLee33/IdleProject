using System.Collections;
using System.Collections.Generic;
//using System;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour {

    public ScriptableCurrencyManager scriptableCurrencyManager;
    public static CurrencyManager currencyManagerInstance;

    private NetManager netManager;
    private DateTimeTest dateTimeTest;
    private string scientificFormat = "#.000.e+0";

    private Text currencyText;
    private Text netText;
    private Text prestigeText;

    private void OnEnable()
    {
        if (currencyManagerInstance == null)
        {
            currencyManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    private void Start ()
    {
        netManager = NetManager.netManagerInstance;
        currencyText = GameObject.Find("CurrencyText").GetComponent<Text>();
        netText = GameObject.Find("NetText").GetComponent<Text>();
        prestigeText = GameObject.Find("PrestigeText").GetComponent<Text>();
        dateTimeTest = GetComponent<DateTimeTest>();

        ApplyOfflineTime();
        StartCoroutine(IdleCurrency());
    }


    private void Update () //Update text components to display currency and bee values
    {
        float incPrestige = (scriptableCurrencyManager.totalCurrency / 100); //Calculate prestiage player will recieve at any time for a reset
        //long longIncPrestige = Convert.ToInt64(incPrestige);

        if (scriptableCurrencyManager.scientificNotation) //Scientific Notation
        {
            currencyText.text = "Currency: $" + scriptableCurrencyManager.totalCurrency.ToString(scientificFormat);
            netText.text = "Fish per second: " + scriptableCurrencyManager.netCapacity.ToString(scientificFormat);
            prestigeText.text = "Prestige: " + incPrestige.ToString(scientificFormat);
        }
        else //Suffixed Notation
        {
            currencyText.text = "Currency: $" + LargeNumber.ToString(scriptableCurrencyManager.totalCurrency);
            netText.text = "Fish per second: " + LargeNumber.ToString(scriptableCurrencyManager.netCapacity);
            prestigeText.text = "Prestige: " + LargeNumber.ToString(incPrestige);
        }
    }


    public void GenerateBees() //Button for catching fish
    {
        float fishValue = (scriptableCurrencyManager.fishBaseValue * scriptableCurrencyManager.currencyMulti) * (1f * (scriptableCurrencyManager.prestigeCurrency * scriptableCurrencyManager.prestigeMulti));
        scriptableCurrencyManager.totalCurrency += fishValue * Random.Range(0, 4);
    }


    public void RemoveCurrency(float costAmount) //Used by buttons for removing currency
    {
        scriptableCurrencyManager.totalCurrency -= costAmount;
    }


    private IEnumerator IdleCurrency() //Generate currency per second
    {
        while (true)
        {
            float fishValue = (scriptableCurrencyManager.fishBaseValue * scriptableCurrencyManager.currencyMulti) * (1f * (scriptableCurrencyManager.prestigeCurrency * scriptableCurrencyManager.prestigeMulti));
            yield return new WaitForSeconds(1);
            scriptableCurrencyManager.totalCurrency += scriptableCurrencyManager.netCapacity * fishValue;
        }
    }


    private void ApplyOfflineTime() //Generate currency/bees when offline
    {
        float fishValue = (scriptableCurrencyManager.fishBaseValue * scriptableCurrencyManager.currencyMulti) * (1f * (scriptableCurrencyManager.prestigeCurrency * scriptableCurrencyManager.prestigeMulti));

        //Convert our time offline into a float
        float seconds = (float)dateTimeTest.offlineTime.TotalSeconds;
        float offlineCurrency = scriptableCurrencyManager.netCapacity * fishValue * seconds;
        Debug.Log("Offline currency: " + offlineCurrency);

        //Add our offline time into our currency
        scriptableCurrencyManager.totalCurrency += offlineCurrency;
    }


    public void ApplyPrestige() //Apply prestige when resetting
    {
        float incPrestige = (scriptableCurrencyManager.totalCurrency / 100);
        scriptableCurrencyManager.prestigeCurrency += incPrestige;
    }
}

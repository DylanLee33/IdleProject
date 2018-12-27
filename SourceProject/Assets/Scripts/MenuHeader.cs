using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHeader : MonoBehaviour {

    private CurrencyManager currencyManager;
    private NetManager netManager;

    private Slider slider;
    private Text capacityText;
    private float currentValue;

    //THIS MAY NOT BE NEEDED ANY LONGER

    private void Start()
    {
        currencyManager = CurrencyManager.currencyManagerInstance;
        netManager = NetManager.netManagerInstance;
        slider = GetComponentInChildren<Slider>();
        capacityText = transform.Find("MaxCapacity").GetComponent<Text>();

        //slider.maxValue = storageManager.scriptableStorageManager.beeStorage;
        slider.value = currencyManager.scriptableCurrencyManager.netCapacity;
        capacityText.text = ("Maximum Capacity:" + slider.maxValue);
    }


    private void LateUpdate ()
    {
        slider.value = currencyManager.scriptableCurrencyManager.netCapacity;
    }


    public void UpdateHeader (int capacityValue)
    {
        //slider.maxValue = storageManager.scriptableStorageManager.beeStorage;
        capacityText.text = ("Maximum Capacity:" + capacityValue);
    }
}

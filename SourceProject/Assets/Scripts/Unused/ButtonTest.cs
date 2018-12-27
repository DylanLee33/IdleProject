using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour {

    //private CurrencyManager currencyManager;

    private void Start()
    {
        //currencyManager = GameObject.Find("GameManager").GetComponent<CurrencyManager>();
    }

    private void OnTouchDown()
    {
        Debug.Log("Button Down");
    }

    private void OnTouchUp()
    {
        Debug.Log("Button Up");
    }

    private void OnTouchStationary()
    {
        Debug.Log("Button Stationary");
    }

    private void OnTouchExit()
    {
        Debug.Log("Button Canceled");
    }
}

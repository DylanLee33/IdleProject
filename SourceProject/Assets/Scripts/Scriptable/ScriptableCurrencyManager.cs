using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrencyManager", menuName = "CurrencyManager")]
public class ScriptableCurrencyManager : ScriptableObject {
    
    public float totalCurrency;
    public float prestigeCurrency;
    public float prestigeMulti;
    public float netCapacity;
    public float fishBaseValue;
    public float currencyMulti;
    public bool scientificNotation;

    //Floats seem to cap at 38 0's, this is probably enough, doubles can be used for much higher values
}

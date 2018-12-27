using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Button", menuName = "UpgradeButton")]
public class UpgradeButton : ScriptableObject
{
    [Header("General")]
    public string nameText;
    public string researchText;
    public string upgradeText;
    public float costAmount;
    public float costMultiplier;
    public int currentPurchaseAmount;
    public int maxPurchaseAmount;

    [Header("Default")]
    public float defaultCostAmount;
    public int defaultCurrentPurchaseAmount;

    [Header("Fish Value")]
    public float valueMultiplier;

    [Header("Net Capacity")]
    public float netCapacity;

    [Header("Storage")]
    public float storageMulti;

    [Header("Colors")]
    public Color normalColor;
    public Color purchasableColor;
}

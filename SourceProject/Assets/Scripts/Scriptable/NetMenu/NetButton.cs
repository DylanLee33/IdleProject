using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Button", menuName = "NetButton")]
public class NetButton : ScriptableObject {

    public string nameText;
    public string researchText;
    public string netText;
    public float costAmount;
    public int netCapacity;
    public int containerInt;
    public int menuInt;
    public bool hasPurchased;
    public bool scientificNotation;

    [Header("Colors")]
    public Color normalColor;
    public Color purchasableColor;
}

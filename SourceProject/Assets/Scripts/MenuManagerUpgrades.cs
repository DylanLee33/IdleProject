using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManagerUpgrades : MonoBehaviour
{
    private UpgradeButtonValue[] upgradeButtons;
    private Button[] buttons;
    private GameObject[] labels;
    private float[] costAmounts;

    private void Start()
    {
        Arrays();
    }


    private void Update()
    {
        Arrays();
    }


    private void Arrays()
    {
        //CAN I AVOID UPDATING THESE EVERY FRAME
        buttons = GetComponentsInChildren<Button>();
        upgradeButtons = GetComponentsInChildren<UpgradeButtonValue>();

        //CAN I CLEAN THESE ARRAYS
        costAmounts = new float[upgradeButtons.Length];
        labels = new GameObject[upgradeButtons.Length];

        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            costAmounts[i] = upgradeButtons[i].costAmount;
            labels[i] = buttons[i].transform.parent.gameObject;
        }
    }


    public void TempResetFunction() //Broadcast message to children to reset the scriptable objects to their default values
    {
        gameObject.BroadcastMessage("DefaultValues");
    }
}

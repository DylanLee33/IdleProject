using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManagerStorage : MonoBehaviour
{
    private NetButtonDisplay[] buttonDisplays;
    private Button[] buttons;
    private GameObject[] labels;

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
        buttonDisplays = GetComponentsInChildren<NetButtonDisplay>();

        //CAN I CLEAN THESE ARRAYS
        labels = new GameObject[buttonDisplays.Length];

        for (int i = 0; i < buttonDisplays.Length; i++)
        {
            labels[i] = buttons[i].transform.parent.gameObject;
        }
    }


    public void RemoveButtons(int buttonIndex)
    {
        //Remove the button that was pressed and buttons previous to that button in the menu
        for (int i = 0; i < buttonIndex; i++)
        {
            if (labels[i] != null)
            {
                buttonDisplays[i].netButton.hasPurchased = true;
                //Destroy(labels[i]);
            }
        }

        //Change the button number of each remaining button by the number of buttons removed
        for (int i = 0; i < buttonDisplays.Length; i++)
        {
            buttonDisplays[i].netButton.menuInt -= buttonIndex;
        }
    }
}

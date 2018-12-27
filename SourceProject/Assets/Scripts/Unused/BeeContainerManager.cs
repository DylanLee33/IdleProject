using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeContainerManager : MonoBehaviour {

    public GameObject[] beeContainers;
    private GameObject beecontainer;
    public int currentContainer;

    void Start ()
    {
        currentContainer = PlayerPrefs.GetInt("currentContainerIndex");

        //MachineArray01(currentMachine);
    }


    //Method 01 for machines, keeps and would load all every time and hide them
    //Longer starting load time but smoother at runtime (I think)
    public void MachineArray01(int currentContainer)
    {
        //Get all the children into an array & set them to inactive
        //Find the member of the array equal to the current machine index
        //and set that machine to active
        beeContainers = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            beeContainers[i] = transform.GetChild(i).gameObject;
            beeContainers[i].SetActive(false);
            //Minus 1 off the currentmachine so the machine int can be set 
            //to the exact value of the machine, ignoring array 0
            if (i == currentContainer)
            {
                beeContainers[i].SetActive(true);
            }
        }
    }
}

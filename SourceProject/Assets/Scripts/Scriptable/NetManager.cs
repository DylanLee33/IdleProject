using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetManager : MonoBehaviour {

    public ScriptableNetManager scriptableNetManager;
    public static NetManager netManagerInstance;

    private GameObject[] beeContainers;
    private GameObject beecontainer;

    private void OnEnable()
    {
        if (netManagerInstance == null)
        {
            netManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }


    private void Start ()
    {
        BeeContainer02(scriptableNetManager.currentContainer);
    }


    //I think I can just put this on the currency manager, no need for these to be on here
    /*public void ApplyStorageMulti() //Used by buttons after upgrading storage to apply any multipliers
    {
        scriptableStorageManager.multipliedCapacity = Mathf.RoundToInt(scriptableStorageManager.netCapacity * scriptableStorageManager.capcityMulti);
    }*/


    public void BeeContainer02(int currentContainer) //Switch the current container with the upgraded container
    {
        beeContainers = Resources.LoadAll<GameObject>("Nets");
        scriptableNetManager.currentContainer = currentContainer;

        //Destroy existing container
        if (beecontainer) { Destroy(beecontainer); }

        //Loop through container array until it hits container matching the selected upgrade (int currentContainer)
        //Instantiate that container
        for (int i = 0; i < beeContainers.Length; i++)
        {
            if (i == currentContainer)
            {
                beecontainer = Instantiate(beeContainers[i], transform.position, transform.rotation);
                beecontainer.transform.parent = gameObject.transform;
            }
        }
    }
}

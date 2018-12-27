using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuScript : MonoBehaviour {

    public GameObject menuTest;

    public bool touchDown;

    private void Start()
    {
       menuTest.SetActive(false);
    }


    private void OnTouchDown()
    {
        touchDown = true;
        Debug.Log("Button Down");
    }


    private void OnTouchUp()
    {
        if (touchDown) //Check if the touch began on the object
        {
            menuTest.SetActive(true);
        }

        touchDown = false;
        Debug.Log("Button Up");
    }


    private void OnTouchStationary()
    {
        Debug.Log("Button Stationary");
    }


    private void OnTouchCanceled()
    {
        touchDown = false;
        Debug.Log("Button Canceled");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DateTimeTest : MonoBehaviour {

    public TimeSpan offlineTime;

    private DateTime currentDate;
    private DateTime oldDate;
    private long parsedNumber;

    private void Start ()
    {
        //Store the current time when it starts
        currentDate = System.DateTime.Now;

        //Check if a saved time exists (Isnt first launch ever)
        if (long.TryParse(PlayerPrefs.GetString("sysString"), out parsedNumber))
        {
            //Convert the old time from binary to a DataTime variable
            oldDate = DateTime.FromBinary(parsedNumber);
            Debug.Log("oldDate: " + oldDate);

            //Use the Subtract method and store the result as a timespand variable
            offlineTime = currentDate.Subtract(oldDate);
            Debug.Log("Offline time: " + offlineTime);
        }
	}


    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());
        Debug.Log("Saving this date to prefs: " + System.DateTime.Now);
    }
}

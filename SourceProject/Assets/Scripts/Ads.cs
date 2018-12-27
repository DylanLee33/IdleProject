using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class Ads : MonoBehaviour {

    private float adTimer;
    public Text adTimerText;

    private void Start()
    {
        adTimer = PlayerPrefs.GetFloat("AdTimer");
    }


    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("AdTimer", adTimer);
    }


    private void Update()
    {
        if (adTimer > 0)
        {
            adTimer -= Time.deltaTime;

            int sec = (int)(adTimer % 60);
            int min = (int)(adTimer / 60) % 60;
            int hour = (int)(adTimer / 3600) % 24;

            adTimerText.text = string.Format("{0:0}:{1:00}:{2:00}", hour, min, sec);
        }
        else
        {
            adTimer = 0f;
        }
    }


    public void ShowRewardedVideo()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        Advertisement.Show("rewardedVideo", options);
    }

    private void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            adTimer = 39600f;
            Debug.Log("Video completed - Offer a reward to the player");

        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("Video was skipped - Do NOT reward the player");

        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClearPlayerPref : MonoBehaviour {

    [MenuItem("Edit/Reset Playerprefs")]

    public static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}

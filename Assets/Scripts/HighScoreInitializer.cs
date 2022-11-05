using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreInitializer : MonoBehaviour
{
    public TextMeshProUGUI oopsHigh1;
    public TextMeshProUGUI oopsHigh2;
    public TextMeshProUGUI oopsHigh3;
    public TextMeshProUGUI oopsHigh4;
    public TextMeshProUGUI oopsHigh5;
    public TextMeshProUGUI oopsHigh1Name;
    public TextMeshProUGUI oopsHigh2Name;
    public TextMeshProUGUI oopsHigh3Name;
    public TextMeshProUGUI oopsHigh4Name;
    public TextMeshProUGUI oopsHigh5Name;

    void Start()
    {
        if(!PlayerPrefs.HasKey("HasHighScores"))
        {
            PlayerPrefs.SetInt("HasHighScores", 1);
            PlayerPrefs.SetFloat("OopsHigh1", 599.999f);
            PlayerPrefs.SetFloat("OopsHigh2", 599.999f);
            PlayerPrefs.SetFloat("OopsHigh3", 599.999f);
            PlayerPrefs.SetFloat("OopsHigh4", 599.999f);
            PlayerPrefs.SetFloat("OopsHigh5", 599.999f);
            PlayerPrefs.SetString("OopsHigh1Name", "---");
            PlayerPrefs.SetString("OopsHigh2Name", "---");
            PlayerPrefs.SetString("OopsHigh3Name", "---");
            PlayerPrefs.SetString("OopsHigh4Name", "---");
            PlayerPrefs.SetString("OopsHigh5Name", "---");
        }

        oopsHigh1.SetText(string.Format("{0:00}:{1:00}:{2:000}", Mathf.FloorToInt(PlayerPrefs.GetFloat("OopsHigh1") / 60), Mathf.FloorToInt(PlayerPrefs.GetFloat("OopsHigh1") % 60), PlayerPrefs.GetFloat("OopsHigh1") % 1 * 1000));
        oopsHigh2.SetText(string.Format("{0:00}:{1:00}:{2:000}", Mathf.FloorToInt(PlayerPrefs.GetFloat("OopsHigh2") / 60), Mathf.FloorToInt(PlayerPrefs.GetFloat("OopsHigh2") % 60), PlayerPrefs.GetFloat("OopsHigh2") % 1 * 1000));
        oopsHigh3.SetText(string.Format("{0:00}:{1:00}:{2:000}", Mathf.FloorToInt(PlayerPrefs.GetFloat("OopsHigh3") / 60), Mathf.FloorToInt(PlayerPrefs.GetFloat("OopsHigh3") % 60), PlayerPrefs.GetFloat("OopsHigh3") % 1 * 1000));
        oopsHigh4.SetText(string.Format("{0:00}:{1:00}:{2:000}", Mathf.FloorToInt(PlayerPrefs.GetFloat("OopsHigh4") / 60), Mathf.FloorToInt(PlayerPrefs.GetFloat("OopsHigh4") % 60), PlayerPrefs.GetFloat("OopsHigh4") % 1 * 1000));
        oopsHigh5.SetText(string.Format("{0:00}:{1:00}:{2:000}", Mathf.FloorToInt(PlayerPrefs.GetFloat("OopsHigh5") / 60), Mathf.FloorToInt(PlayerPrefs.GetFloat("OopsHigh5") % 60), PlayerPrefs.GetFloat("OopsHigh5") % 1 * 1000));
        oopsHigh1Name.SetText(PlayerPrefs.GetString("OopsHigh1Name"));
        oopsHigh2Name.SetText(PlayerPrefs.GetString("OopsHigh2Name"));
        oopsHigh3Name.SetText(PlayerPrefs.GetString("OopsHigh3Name"));
        oopsHigh4Name.SetText(PlayerPrefs.GetString("OopsHigh4Name"));
        oopsHigh5Name.SetText(PlayerPrefs.GetString("OopsHigh5Name"));
    }
}

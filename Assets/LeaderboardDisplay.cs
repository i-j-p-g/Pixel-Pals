using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI leaderboardText;
    void Start()
    {
        string allTimes = PlayerPrefs.GetString("RunTimes", "");
        if (string.IsNullOrEmpty(allTimes))
        {
            leaderboardText.text = "No runs recorded yet.";
            return;
        }
        string[] timeStrings = allTimes.Split(',');
        leaderboardText.text = "Your Times:\n";

        for (int i = 0; i < timeStrings.Length; i++)
        {
            if (float.TryParse(timeStrings[i], out float t))
            {
                int minutes = Mathf.FloorToInt(t / 60f);
                int seconds = Mathf.FloorToInt(t % 60f);
                leaderboardText.text += $"{i + 1}. {minutes:00}:{seconds:00}\n";
            }
        }
    }

    
    void Update()
    {
        
    }
}

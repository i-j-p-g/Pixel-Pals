using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI leaderboardText;

    void Start()
    {
        float lastTime = PlayerPrefs.GetFloat("LastTime", 0f);
        int minutes = Mathf.FloorToInt(lastTime / 60f);
        int seconds = Mathf.FloorToInt(lastTime % 60f);
        leaderboardText.text = string.Format("Your Time: {0:00}:{1:00}", minutes, seconds);
    }
}

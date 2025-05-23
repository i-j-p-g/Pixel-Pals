using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finishText;

    void Start()
    {
        float time = PlayerPrefs.GetFloat("LastRunTime", 0f);
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        finishText.text = $"Your Time: {minutes:00}:{seconds:00}";
    }
}

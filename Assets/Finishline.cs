using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finishline : MonoBehaviour
{
   // private void OnTriggerEnter2D(Collider2D collision)
    //{
        //if (collision.tag == "Player")
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      //  }
    //}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float time = GameObject.Find("TimerManager").GetComponent<Timer>().GetElapsedTime();

            // load current list and add new time
            string existingTimes = PlayerPrefs.GetString("RunTimes", "");
            if (string.IsNullOrEmpty(existingTimes))
            {
                PlayerPrefs.SetString("RunTimes", time.ToString());
            }
            else
            {
                PlayerPrefs.SetString("RunTimes", existingTimes + "," + time);
            }
            PlayerPrefs.Save();
            Debug.Log("Saved Time: " + PlayerPrefs.GetString("RunTimes"));
            SceneManager.LoadScene("LeaderboardScene");
        }
    }
}

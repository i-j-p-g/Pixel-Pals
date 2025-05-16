using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish_line_script : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        {
            Debug.Log("Finish line trigger detected with: " + other.name);

            if (other.CompareTag("Player"))
            {
                Debug.Log("Player detected at finish line.");

                // save the player's time
                float time = GameObject.Find("TimerManager").GetComponent<Timer>().GetElapsedTime();
                PlayerPrefs.SetFloat("LastTime", time);

                Debug.Log("Time saved: " + time);

                // load leaderboard scene
                SceneManager.LoadScene("LeaderboardScene");
            }
        }

        
    }
       
    }

   
   
      

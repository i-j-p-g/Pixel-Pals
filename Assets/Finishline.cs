using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finishline : MonoBehaviour
{
    // private void OnTriggerEnter2D(Collider2D collision)
    //{
    //  if (collision.tag == "Player")
    //{
    //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}
    //}

    [SerializeField] private Timer timer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Timer timer = FindObjectOfType<Timer>();
            if (timer != null)
            {
                float time = timer.GetElapsedTime();
                PlayerPrefs.SetFloat("LastRunTime", time);
                PlayerPrefs.Save();
                Debug.Log("Saved time: " + time);
            }
            else
            {
                Debug.LogError("Timer script not found in scene!");
            }

            // Load the finish scene
            SceneManager.LoadScene("FinishScene");
        }
    }

}

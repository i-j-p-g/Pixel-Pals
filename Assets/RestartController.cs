using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}

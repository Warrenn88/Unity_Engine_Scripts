using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class DoorController : MonoBehaviour
{
    public string nextSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameObject.FindGameObjectsWithTag("Dog").Length == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
        }
    }
}

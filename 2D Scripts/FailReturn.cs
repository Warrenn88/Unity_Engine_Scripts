using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallReturn : MonoBehaviour
{
    public string levelrestartname;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelrestartname);
        }
    }
}

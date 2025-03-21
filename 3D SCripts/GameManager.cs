using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float timeRemaining = 60f;
    public TMP_Text timerText;
    private bool gameEnded = false;

    private bool redBallScored = false;
    private bool blueBallScored = false;
    private bool yellowBallScored = false;
    private bool greenBallScored = false;

    public AudioClip scoreSFX;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    void Update()
    {
        if (gameEnded) return;

        timeRemaining -= Time.deltaTime;
        timerText.text = "HIGH PRESSURE TIMER: " + Mathf.Ceil(timeRemaining).ToString();

        if (timeRemaining <= 0)
        {
            Debug.Log("[GameManager] Time ran out! Game Over.");
            LoseGame();
        }

        if (redBallScored && blueBallScored && yellowBallScored && greenBallScored)
        {
            Debug.Log("[GameManager] All balls have touched their corners! WIN.");
            WinGame();
        }
    }

    public void BallScored(string ballColor)
{
    Debug.Log($"[GameManager] BallScored() called with color: {ballColor}");

    if (ballColor == "red") 
    {
        redBallScored = true;
        audioSource.PlayOneShot(scoreSFX);
        Debug.Log("[GameManager] Red Ball scored.");
    }
    else if (ballColor == "blue") 
    {
        blueBallScored = true;
        audioSource.PlayOneShot(scoreSFX);
        Debug.Log("[GameManager] Blue Ball scored.");
    }
    else if (ballColor == "yellow") 
    {
        yellowBallScored = true;
        audioSource.PlayOneShot(scoreSFX);
        Debug.Log("[GameManager] Yellow Ball scored.");
    }
    else if (ballColor == "green") 
    {
        greenBallScored = true;
        audioSource.PlayOneShot(scoreSFX);
        Debug.Log("[GameManager] Green Ball scored.");
    }
    else
    {
        Debug.LogWarning($"[GameManager] Unknown ball color received: {ballColor}");
        return;
    }

    Debug.Log($"[GameManager] Score Status - Red: {redBallScored}, Blue: {blueBallScored}, Yellow: {yellowBallScored}, Green: {greenBallScored}");
}

    void WinGame()
    {
        gameEnded = true;
        Debug.Log("[GameManager] Loading Win Scene...");
        SceneManager.LoadScene("WinScene");
    }

    void LoseGame()
    {
        gameEnded = true;
        Debug.Log("[GameManager] Loading Loss Scene...");
        SceneManager.LoadScene("LossScene");
    }
}

using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public string targetColor; 
    private bool hasScored = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasScored && other.CompareTag(targetColor))
        {
            hasScored = true;

            Debug.Log($"[BallCollision] {gameObject.name} touched {other.tag}, sending '{targetColor}' to GameManager.");

            FindFirstObjectByType<GameManager>().BallScored(targetColor);
        }
    }
}

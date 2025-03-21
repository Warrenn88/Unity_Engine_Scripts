using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Vector2 spawnAreaMin = new Vector2(-7.5f, -3.75f); 
    public Vector2 spawnAreaMax = new Vector2(7.2f, 4.2f);  
    public float spawnHeight = 2.0f; 
    public float checkRadius = .5f; 

    void Start()
    {
        SpawnAtRandomLocation();
    }

    void SpawnAtRandomLocation()
    {
        Vector3 randomPosition;
        int attempts = 0;
        bool validPosition = false;

        do
        {
            float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float randomZ = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            randomPosition = new Vector3(randomX, spawnHeight, randomZ);

            
            validPosition = !Physics.CheckSphere(randomPosition, checkRadius);

            attempts++;

            if (attempts > 10)
            {
                Debug.LogWarning("Could not find a valid spawn position after 10 attempts.");
                break;
            }

        } while (!validPosition);

        transform.position = randomPosition;
    }
}

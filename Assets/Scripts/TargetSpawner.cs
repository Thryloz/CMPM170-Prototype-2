using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public float minInterval = 1f;
    public float maxInterval = 2f;

    float timeSinceSpawn = 0f;
    float newSpawnTime = 1.5f;

    void Start()
    {
        newSpawnTime = Random.Range(minInterval, maxInterval);

    }

    void Update()
    {
        timeSinceSpawn += Time.deltaTime;

        if (timeSinceSpawn >= newSpawnTime){
            Instantiate(targetPrefab, transform.position, Quaternion.identity);

            timeSinceSpawn = 0f;
            newSpawnTime = Random.Range(minInterval, maxInterval);
        }
    }
    
}


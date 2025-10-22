
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public Target target;
    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 2f;

    public float timer;
    public float spawnTime;

    private void Start()
    {
        timer = 0f;
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            Instantiate(target, transform.position, Quaternion.identity);
            timer = 0f;
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        }

    }
}

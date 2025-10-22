using System.IO;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public float minInterval = 1f;
    public float maxInterval = 2f;

    public float verticalSpeed = 2f;

    float timeSinceSpawn = 0f;
    float newSpawnTime = 1.5f;

    public enum Direction
    {
        Right,
        Left
    }

    public Direction direction;

    void Start()
    {
        newSpawnTime = Random.Range(minInterval, maxInterval);
        verticalSpeed = Random.Range(3f, 5f);
    }

    void Update()
    {
        timeSinceSpawn += Time.deltaTime;

        if (timeSinceSpawn >= newSpawnTime){
            MovingTarget tmp = Instantiate(targetPrefab, transform.position, Quaternion.identity).GetComponent<MovingTarget>();

            if (direction == Direction.Left)
            {
                tmp.SetDirection(1);
            }
            else
            {
                tmp.SetDirection(0);
            }

            timeSinceSpawn = 0f;
            newSpawnTime = Random.Range(minInterval, maxInterval);
        }

        transform.position += Vector3.up * verticalSpeed * Time.deltaTime; //move right per frame
    }

    private void OnCollisionEnter(Collision collision)
    {
        verticalSpeed = -verticalSpeed;
    }

}


using System;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public static event Action OnTargetHit;
    public float minSpeed = 3f;
    public float maxSpeed = 5f;

    private float speed;

    private int direction;

    void Start()
    {
        Destroy(gameObject, 5f);//auto delete after 5 seconds
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    public void SetDirection(int value)
    {
        direction = value;
    }

    void Update()
    {
        if (direction == 0)
        {
            transform.position += Vector3.right * speed * Time.deltaTime; //move right per frame
        } else
        {
            transform.position += Vector3.left * speed * Time.deltaTime; //move right per frame
        }
    }

    public void DestroyTarget()
    {
        OnTargetHit?.Invoke();
        Destroy(gameObject);
    }
}
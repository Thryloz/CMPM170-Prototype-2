using System;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public static event Action OnTargetHit;
    public float minSpeed = 3f;
    public float maxSpeed = 5f;

    private float speed;

    void Start()
    {
        Destroy(gameObject, 5f);//auto delete after 5 seconds
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime; //move right per frame
    }

    public void DestroyTarget()
    {
        OnTargetHit?.Invoke();
        Destroy(gameObject);
    }
}
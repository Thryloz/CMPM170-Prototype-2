using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static event Action OnTargetDestroy;
    public float minVelocity = 200f;
    public float maxVelocity = 500f;

    public float lifetime = 5f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float velocity = UnityEngine.Random.Range(minVelocity, maxVelocity);
        rb.AddForce(Vector3.right * velocity);
        Destroy(gameObject, lifetime);
    }

    public void DestroyTarget()
    {
        OnTargetDestroy?.Invoke();
        Destroy(gameObject);
    }
}

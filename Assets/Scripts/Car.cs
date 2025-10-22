using System;
using UnityEngine;

public class Car : MonoBehaviour
{
    public static event Action OnCarMiss;


    public float lifetime = 5f;
    public float explosionRadius = 4f;
    public GameObject explosion;
    public GameObject model;
    public GameObject cam;
    public LayerMask targetLayer;

    private CameraShake cameraShake;
    private Rigidbody rb;

    private bool hasCheckedAOE = false;

    private float timer;
    private void Awake()
    {
        cam = GameObject.FindWithTag("MainCamera");
        rb = GetComponent<Rigidbody>();
        cameraShake = cam.GetComponent<CameraShake>();
    }

    private void Start()
    {
        explosion.SetActive(false);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifetime)
        {
            Explode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    private void Explode()
    {
        model.SetActive(false);
        explosion.SetActive(true);

        rb.velocity = Vector3.zero;

        if (!hasCheckedAOE)
        {
            CheckForTargets();
            hasCheckedAOE = true;
        }

        StartCoroutine(cameraShake.Shake());

        Destroy(gameObject, 1f);
    }

    private void CheckForTargets()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, targetLayer);

        if (colliders.Length == 0)
        {
            OnCarMiss?.Invoke();
        }

        foreach (Collider c in colliders)
        {
            if (c.GetComponent<MovingTarget>() != null)
            {
                c.GetComponent<MovingTarget>().DestroyTarget();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
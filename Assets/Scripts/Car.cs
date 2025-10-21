using UnityEngine;

public class Car : MonoBehaviour
{
    public float lifetime = 5f;
    public float explosionRadius = 4f;
    public GameObject explosion;
    public GameObject model;
    public GameObject cam;

    private CameraShake cameraShake;

    private float timer;

    private void Awake()
    {
        cam = GameObject.FindWithTag("MainCamera");
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

        StartCoroutine(cameraShake.Shake());

        Destroy(gameObject, 1f);
    }

    private void CheckForTargets()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider c in colliders)
        {
            if (c.gameObject.name == "Target")
            {
                // call target destroy function
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}

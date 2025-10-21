using UnityEngine;

public class Car : MonoBehaviour
{
    public float lifetime = 5f;
    public GameObject explosion;
    public GameObject model;

    private float timer;

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

        Destroy(gameObject, 1f);
    }

}

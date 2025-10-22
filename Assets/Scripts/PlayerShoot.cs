using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public Rigidbody projectile;
    public float launchVelocity = 700f;
    public Transform spawn_L;
    public Transform spawn_R;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody car;

            // add a bit of random to it's spawn position
            float random_x = Random.Range(-.25f, .25f);
            float random_y = Random.Range(-.25f, .25f);
            Vector3 spawnPosition = new Vector3(spawn_L.position.x + random_x, spawn_L.position.y + random_y);
            
            car = Instantiate(projectile, spawnPosition, transform.rotation);
            car.GetComponent<Rigidbody>().AddForce(transform.forward * launchVelocity);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Rigidbody car;

            // add a bit of random to it's spawn position
            float random_x = Random.Range(-.25f, .25f);
            float random_y = Random.Range(-.25f, .25f);
            Vector3 spawnPosition = new Vector3(spawn_R.position.x + random_x, spawn_R.position.y + random_y);

            car = Instantiate(projectile, spawnPosition, transform.rotation);
            car.GetComponent<Rigidbody>().AddForce(transform.forward * launchVelocity);
        }
    }
}

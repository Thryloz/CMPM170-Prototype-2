using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public Rigidbody projectile;
    public float launchVelocity = 700f;
    public Transform spawn;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody car;

            // add a bit of random to it's spawn position
            float random_x = Random.Range(-.5f, .5f);
            float random_y = Random.Range(-.5f, .5f);
            Vector3 spawnPosition = new Vector3(spawn.position.x + random_x, spawn.position.y + random_y);
            
            car = Instantiate(projectile, spawnPosition, transform.rotation);
            car.GetComponent<Rigidbody>().AddForce(transform.forward * launchVelocity);
        }
    }
}

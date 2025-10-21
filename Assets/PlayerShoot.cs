using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public Rigidbody projectile;
    public float launchVelocity = 700f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody car;
            car = Instantiate(projectile, transform.position, transform.rotation);
            car.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * launchVelocity);
        }
    }
}

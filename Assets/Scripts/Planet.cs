using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject player;
    public float speed = 10f;

    private Rigidbody rb;
    private Vector3 direction;

    public float addForceInterval = 10f;
    private float timer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
        direction = player.transform.position - transform.position;
        rb.AddForce(direction * speed);
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        transform.LookAt(player.transform.position);
        transform.Rotate(Vector3.up * 90);

        if (timer > addForceInterval)
        {
            rb.AddForce(direction * speed);
            timer = 0f;
        }
    }

}

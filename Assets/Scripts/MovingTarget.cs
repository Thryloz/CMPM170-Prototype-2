using System;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public static event Action OnTargetHit;
    public float minSpeed = 3f;
    public float maxSpeed = 5f;
    public GameObject text;
    public GameObject actualTarget;
    
    private float speed;

    private int direction;

    private bool targetDestroyed = false;

    void Start()
    {
        Destroy(gameObject, 5f);//auto delete after 5 seconds
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
        text.SetActive(false);
        actualTarget.SetActive(true);
    }

    public void SetDirection(int value)
    {
        direction = value;
    }

    void Update()
    {
        if (targetDestroyed)
        {
            transform.position += Vector3.up * 10f * Time.deltaTime;
            return;
        }

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
        targetDestroyed = true;
        actualTarget.SetActive(false);  
        OnTargetHit?.Invoke();
        text.SetActive(true);
        Destroy(gameObject, 2f);
    }
}
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    public float speed = 3f;

    void Start()
    {
        Destroy(gameObject, 5f);//auto delete after 5 seconds
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime; //move right per frame
    }
}
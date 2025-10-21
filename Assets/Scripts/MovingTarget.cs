using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 4f;                 
    public Vector3 direction = Vector3.right; 

    [Header("Lifetime / Bounds")]
    public float maxLifetime = 10f;          
    public float offscreenPadding = 0.15f;   

    private float _age;
    private Camera _cam;

    void Awake()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        transform.position += direction.normalized * speed * Time.deltaTime;

        _age += Time.deltaTime;
        if (_age > maxLifetime)
        {
            Destroy(gameObject);
            return;
        }

        if (_cam)
        {
            Vector3 vp = _cam.WorldToViewportPoint(transform.position);
            bool off =
                vp.z < 0f ||
                vp.x < -offscreenPadding || vp.x > 1f + offscreenPadding ||
                vp.y < -offscreenPadding || vp.y > 1f + offscreenPadding;

            if (off) Destroy(gameObject);
        }
    }

    // destroy on collision
    void OnCollisionEnter(Collision _)
    {
        Destroy(gameObject);
    }
}

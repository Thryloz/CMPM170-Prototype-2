using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [Header("Target Prefab")]
    public GameObject targetPrefab;

    [Header("Spawn Timing (seconds)")]
    public float spawnIntervalMin = 0.8f;
    public float spawnIntervalMax = 1.6f;

    [Header("Movement Speeds")]
    public float speedMin = 3f;
    public float speedMax = 7f;

    [Header("Vertical Range (viewport 0..1)")]
    public float minViewportY = 0.25f;
    public float maxViewportY = 0.75f;

    private float _nextSpawnTime;
    private Camera _cam;

    void Awake()
    {
        _cam = Camera.main;
        ScheduleNext();
    }

    void Update()
    {
        if (Time.time >= _nextSpawnTime)
        {
            SpawnOne();
            ScheduleNext();
        }
    }

    void ScheduleNext()
    {
        _nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    void SpawnOne()
    {
        if (!targetPrefab || !_cam) return;

        // left or right 
        bool fromLeft = Random.value < 0.5f;

        // random Y 
        float vY = Random.Range(minViewportY, maxViewportY);

        float vX = fromLeft ? -0.05f : 1.05f;

        float depth = Mathf.Max(5f, (_cam.nearClipPlane + 10f));

        Vector3 world = _cam.ViewportToWorldPoint(new Vector3(vX, vY, depth));

        GameObject go = Instantiate(targetPrefab, world, Quaternion.identity);

        // movement
        var mt = go.GetComponent<MovingTarget>();
        if (mt)
        {
            mt.speed = Random.Range(speedMin, speedMax);
            mt.direction = fromLeft ? Vector3.right : Vector3.left;
        }
    }

    // spawn band when spawner is selected
    void OnDrawGizmosSelected()
    {
        if (!_cam) _cam = Camera.main;
        if (!_cam) return;

        Gizmos.color = Color.cyan;
        Vector3 a = _cam.ViewportToWorldPoint(new Vector3(0f, minViewportY, _cam.nearClipPlane + 10f));
        Vector3 b = _cam.ViewportToWorldPoint(new Vector3(1f, minViewportY, _cam.nearClipPlane + 10f));
        Vector3 c = _cam.ViewportToWorldPoint(new Vector3(0f, maxViewportY, _cam.nearClipPlane + 10f));
        Vector3 d = _cam.ViewportToWorldPoint(new Vector3(1f, maxViewportY, _cam.nearClipPlane + 10f));

        Gizmos.DrawLine(a, b);
        Gizmos.DrawLine(c, d);
    }
}

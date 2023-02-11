using UnityEngine;

public class TouchErase : MonoBehaviour
{
    // Радиус маски в квадрате
    public const float SqrMaskRadius = 0.140625f;

    [SerializeField] private SpriteMask maskPrefab;
    [SerializeField] private SpriteMask linkPrefab;
    [SerializeField] private float spawnRate = 1f;

    private Vector3 lastPos;
    private float lastTime;

    private void Update()
    {
        if (GameManager.Instance.GameOver)
            return;

        if (Input.touchCount < 1)
            return;

        Vector3 touchPos = GameManager.Instance.TouchPosition;
        float sqrDistToPiggy = GameManager.Instance.GetSqrDistToPiggy(touchPos);

        if (sqrDistToPiggy < Piggy.MaxSqrTouchDistance)
            return;

        float distToLast = (touchPos - lastPos).sqrMagnitude;
        if (distToLast > spawnRate)
        {
            SpriteMask mask = Instantiate(maskPrefab, touchPos, Quaternion.identity);
            mask.transform.parent = transform;

            if (lastTime != 0f && Time.time - lastTime < 0.15f)
                SpawnLink(lastPos, touchPos);

            lastPos = touchPos;
            lastTime = Time.time;
            Wall.OnMaskSpawn(touchPos);
        }
    }

    private void SpawnLink(Vector3 point1, Vector3 point2)
    {
        Vector3 diff = point2 - point1;
        Vector3 midpoint = point1 + diff / 2;
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        SpriteMask link = Instantiate(linkPrefab, midpoint, Quaternion.Euler(0f, 0f, angle));
        link.transform.parent = transform;
        link.transform.localScale = new Vector3(diff.magnitude, 0.75f, 0.75f);
    }
}
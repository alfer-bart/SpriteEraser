using UnityEngine;

public class TouchErase : MonoBehaviour
{
    // Радиус маски в квадрате
    public const float SqrMaskRadius = 0.140625f;

    [SerializeField] private SpriteMask maskPrefab;
    [SerializeField] private float spawnRate = 1f;

    private Vector3 lastPos;

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
            lastPos = touchPos;
            Wall.OnMaskSpawn(touchPos);
        }
    }
}
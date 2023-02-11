using UnityEngine;

public class Piggy : MonoBehaviour
{
    public const float MaxSqrTouchDistance = 1f;

    [SerializeField] private float speed = 1f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.GameOver)
            return;

        if (Input.touchCount < 1)
            return;

        Vector3 touchPos = GameManager.Instance.TouchPosition;
        Vector3 dir = touchPos - transform.position;
        float sqrDist = dir.sqrMagnitude;

        if (sqrDist < MaxSqrTouchDistance && sqrDist > 0.01f)
        {
            rb.AddForce(dir * speed, ForceMode2D.Force);
        }
    }
}
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float distance = 4f;

    private float yPos;

    private void Awake()
    {
        yPos = transform.position.y;
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);

        if (transform.position.x > distance)
            transform.position = new Vector3(-distance, yPos, 0f);

        if (transform.position.x < -distance)
            transform.position = new Vector3(distance, yPos, 0f);
    }
}

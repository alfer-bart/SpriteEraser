using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Vector3 TouchPosition { get; private set; }
    public bool GameOver { get; private set; }

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Piggy piggy;
    [SerializeField] private TextMeshProUGUI statusMessage;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.touchCount < 1)
            return;

        Vector3 touchPos = mainCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
        touchPos.z = 0f;
        TouchPosition = touchPos;
    }

    public float GetSqrDistToPiggy(Vector3 point)
    {
        return (piggy.transform.position - point).sqrMagnitude;
    }

    public void Goal()
    {
        statusMessage.text = "УРА!";
        GameOver = true;
    }
}
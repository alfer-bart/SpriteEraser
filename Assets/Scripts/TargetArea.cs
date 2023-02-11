using UnityEngine;

public class TargetArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Piggy")
        {
            GameManager.Instance.Goal();
        }
    }
}

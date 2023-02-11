using UnityEngine;
using TMPro;

public class TextWobble : MonoBehaviour
{
    [SerializeField] private float amount = 0.1f;
    [SerializeField] private float speed = 1f;

    private TextMeshProUGUI tmp;
    private float index;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        float newScale = 1f + Mathf.Sin(index) * amount;
        tmp.transform.localScale = new Vector3(newScale, newScale, 0);
        index += speed * Time.deltaTime;
    }
}

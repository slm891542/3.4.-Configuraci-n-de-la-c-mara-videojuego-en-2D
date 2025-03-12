using UnityEngine;

public class BubbleMatch : MonoBehaviour
{
    private Rigidbody2D rb;

    public BubbleManager bubbleManager; // Referencia desde BubbleShooter

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Busca BubbleManager si no está asignado
        if (bubbleManager == null)
        {
            bubbleManager = FindFirstObjectByType<BubbleManager>();

            if (bubbleManager == null)
            {
                Debug.LogError("BubbleManager no se encontró en la escena para " + gameObject.name);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            StopBubble();

            // Lo unimos a la cuadrícula
            transform.SetParent(bubbleManager.transform);

            // Checamos coincidencias de color
            bubbleManager.CheckForMatches(gameObject);
        }
    }

    void StopBubble()
    {
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}

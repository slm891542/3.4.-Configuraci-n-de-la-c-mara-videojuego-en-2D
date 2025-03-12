using UnityEngine;

public class BubbleShooter : MonoBehaviour
{
    public GameObject[] bubblePrefabs; // Prefabs de burbujas
    public Transform shootPoint;       // Punto desde donde disparan
    public float shootSpeed = 10f;     // Velocidad del disparo
    public BubbleManager bubbleManager; // Asignado desde el Inspector

    private GameObject currentBubble;

    void Start()
    {
        SpawnNewBubble();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentBubble != null)
        {
            ShootBubble();
        }
    }

    void SpawnNewBubble()
    {
        int index = Random.Range(0, bubblePrefabs.Length);
        currentBubble = Instantiate(bubblePrefabs[index], shootPoint.position, Quaternion.identity);
    }

    void ShootBubble()
    {
        Rigidbody2D rb = currentBubble.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
             rb.simulated = true;
        }

        currentBubble = null;
        Invoke("SpawnNewBubble", 0.5f);
    }
}

using UnityEngine;

public class BubbleGrid : MonoBehaviour
{
    public int rows = 5; // 5 líneas como en el juego original
    public int cols = 8; // Columnas (ajústalo según el tamaño del escenario)
    public float bubbleSize = 1f;
    public GameObject[] bubblePrefabs;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        float offsetX = -(cols / 2f) * bubbleSize + bubbleSize / 2f;
        float offsetY = 4.5f; // Altura inicial ajustable para separarlas del cañón

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                float xPos = offsetX + c * bubbleSize;
                // Agrega un pequeño desplazamiento para crear el patrón de panal
                if (r % 2 == 1)
                {
                    xPos += bubbleSize / 2f;
                }

                Vector2 position = new Vector2(xPos, offsetY - r * bubbleSize);

                GameObject bubble = Instantiate(
                    bubblePrefabs[Random.Range(0, bubblePrefabs.Length)],
                    position,
                    Quaternion.identity
                );

                bubble.transform.SetParent(transform);
                bubble.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }
}

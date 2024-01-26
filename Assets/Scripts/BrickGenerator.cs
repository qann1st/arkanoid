using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    public GameObject brickPrefab;
    public Material[] materials;
    public int rows = 5;
    public int columns = 10;
    public float spacing = 0.2f;
    public float x = 0.1f;
    public float y = 0.1f;

    void Start()
    {
        GenerateBricks();
    }

    void GenerateBricks()
    {
        Vector2 brickSize = brickPrefab.GetComponent<SpriteRenderer>().bounds.size;
        float totalWidth = columns * (brickSize.x + spacing) - spacing;
        float totalHeight = rows * (brickSize.y + spacing) - spacing;

        Vector2 startPosition = new Vector2(x, y);

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                Vector2 spawnPosition = new Vector2(startPosition.x + column * (brickSize.x + spacing),
                                                    startPosition.y - row * (brickSize.y + spacing));
                Material randomMaterial = materials[Random.Range(0, materials.Length)];
                GameObject brick = Instantiate(brickPrefab, spawnPosition, Quaternion.identity, transform);
                brick.GetComponent<Renderer>().material = randomMaterial;
            }
        }
    }
}

using UnityEngine;

public class RandomGenerate1: MonoBehaviour
{
    // ������� ������
    public GameObject[] tilePrefabs;

    // ������� �����
    public int mapWidth = 10;
    public int mapHeight = 10;

    // ������� �����
    public float tileSize = 1f;

    // ����� ��� ��������� ��������� �����
    private void Start()
    {
        GenerateRandomMap();
    }
    public void GenerateRandomMap()
    {
        // �������� �� ���� ������� ����� � ������������� ��������� �����
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                // �������� ��������� ������ ����� �� �������
                int randomTileIndex = Random.Range(0, tilePrefabs.Length);

                // �������� ��������� ���� �� �������
                GameObject randomTilePrefab = tilePrefabs[randomTileIndex];

                // ��������� ������� ��� �������� �����
                Vector3 tilePosition = new Vector3(x * tileSize, y * tileSize, 0f);

                // ������� ��������� ���������� ����� � �������
                Instantiate(randomTilePrefab, tilePosition, Quaternion.identity, transform);
            }
        }
    }
}
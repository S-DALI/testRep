using UnityEngine;

public class RandomGenerate1: MonoBehaviour
{
    // Префабы тайлов
    public GameObject[] tilePrefabs;

    // Размеры карты
    public int mapWidth = 10;
    public int mapHeight = 10;

    // Размеры тайла
    public float tileSize = 1f;

    // Метод для генерации случайной карты
    private void Start()
    {
        GenerateRandomMap();
    }
    public void GenerateRandomMap()
    {
        // Проходим по всем ячейкам карты и устанавливаем случайные тайлы
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                // Получаем случайный индекс тайла из массива
                int randomTileIndex = Random.Range(0, tilePrefabs.Length);

                // Получаем случайный тайл из массива
                GameObject randomTilePrefab = tilePrefabs[randomTileIndex];

                // Вычисляем позицию для текущего тайла
                Vector3 tilePosition = new Vector3(x * tileSize, y * tileSize, 0f);

                // Создаем экземпляр случайного тайла в позиции
                Instantiate(randomTilePrefab, tilePosition, Quaternion.identity, transform);
            }
        }
    }
}
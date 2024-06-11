using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    [SerializeField] private float chunkSize = 5f;
    [SerializeField] private GameObject[] chunkArray;

    [SerializeField] private int mapWidth = 20;
    [SerializeField] private int mapHeight = 10;
    void Start()
    {
        MapGenerator();
    }

    private void MapGenerator()
    {
        for(int x = 0; x < mapWidth;x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                int randomIndexChunk = Random.Range(0, chunkArray.Length);
                GameObject chunk = chunkArray[randomIndexChunk];
                Vector3 chunkPosition = new Vector3(x * chunkSize, y * chunkSize, 0f);
                Instantiate(chunk, chunkPosition, Quaternion.identity, transform);
            }
        }
    }
}

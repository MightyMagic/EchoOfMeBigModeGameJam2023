using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject player;
    [SerializeField] RoomType roomType;

    [Header("Room Properties")]

    private TerrainData terrainData;

    void Awake()
    {
        terrainData = GetComponent<Terrain>().terrainData;
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 position = player.transform.position;

            SpawnDecoration(position);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            GameObject[] decorations = GameObject.FindGameObjectsWithTag("Decoration");
            foreach (GameObject decoration in decorations)
            {
                Destroy(decoration);
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            FillRoom();
        }
    }

    private void SpawnDecoration(Vector3 position)
    {
        int furnitureIndex = Random.Range(0, roomType.furniture.Length);

        if (Random.Range(0, 100) <= roomType.furniture[furnitureIndex].chance)
        {
            return;
        }

        Instantiate(roomType.furniture[furnitureIndex].prefab, position, Quaternion.identity);
    }

    private void FillRoom()
    {
        int step = 10;

        for (int x = 0; x < roomType.roomWidth ; x += step)
        {
            for (int z = 0; z < roomType.roomLength; z += step)
            {
                Vector3 position = new Vector3(x, 5f, z);

                SpawnDecoration(position);
            }
        }
    }

    private void AddSpikes()
    {
        int heightmapWidth = 10; // terrainData.heightmapResolution;
        int heightmapHeight = 10; // terrainData.heightmapResolution;
        float[,] heights = terrainData.GetHeights(50, 50, heightmapWidth, heightmapHeight);

        for (int x = 0; x < heightmapWidth; x++)
        {
            for (int y = 0; y < heightmapHeight; y++)
            {
                float cos = Mathf.Cos(x);
                float sin = -Mathf.Sin(y);
                heights[x, y] = (cos + sin) / 250;
            }
        }

        terrainData.SetHeights(50, 50, heights);
    }
}

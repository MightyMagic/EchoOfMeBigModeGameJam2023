using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject player;

    [Header("Room Properties")]

    [Header("Decoration")]
    [Header("Decorations")]
    public GameObject[] furnitureSelection;

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
            SpawnSomething();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Destroy(GameObject.FindWithTag("Decoration"));
        }
    }

    private void SpawnSomething()
    {
        int furnitureIndex = Random.Range(0, furnitureSelection.Length);
        Vector3 position = player.transform.position; // new Vector3(10, 1, 10);


        Instantiate(furnitureSelection[furnitureIndex], position, Quaternion.identity);
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

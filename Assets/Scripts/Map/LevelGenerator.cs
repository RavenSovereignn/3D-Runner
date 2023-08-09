using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private float spawnTilePos = 0;
    private float tileLength = 394;
    private int startTiles = 6;

    [SerializeField] private Transform Player;

    private List<GameObject> activeTiles = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < startTiles; i++)
        {
            SpawnTile(Random.Range(0,tilePrefabs.Length));
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.position.z -500 > spawnTilePos - (startTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }
    private void SpawnTile(int tileIndex)
    {
        GameObject nextTile =Instantiate(tilePrefabs[tileIndex],transform.forward * spawnTilePos, transform.rotation);
        activeTiles.Add(nextTile);
        spawnTilePos += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}

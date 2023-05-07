using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunksPlacerLeft : MonoBehaviour
{
    public Transform Player;
    public Chunk[] ChunkPrefabs;
    public Chunk FirstChunk;
    public float spawnDistance;

    private List<Chunk> spawnedChunks = new List<Chunk>();

    void Start()
    {
        spawnedChunks.Add(FirstChunk);
    }


    void Update()
    {
        if (Player.position.x < spawnedChunks[spawnedChunks.Count - 1].Begin.position.x - spawnDistance)
        {
            SpawnChunk();
        }
    }
    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].Begin.position - newChunk.End.localPosition;
        spawnedChunks.Add(newChunk);
    }
    public void ClearChanks()
    {
        Destroy(GameObject.FindWithTag("SpawnedChunk"));
        spawnedChunks.Add(FirstChunk);
    }
}

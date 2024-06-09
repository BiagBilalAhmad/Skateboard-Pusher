using System.Collections.Generic;
using UnityEngine;

public class InfinitePathGenerator : MonoBehaviour
{
    [Header("Path Settings")]
    public GameObject[] pathPrefabs; // Array of path prefabs to choose from
    public int initialPathCount = 5; // Number of initial path segments
    public float pathLength = 10f; // Length of each path segment

    [Header("Player")]
    public Transform playerTransform; // Player's transform

    private List<GameObject> activePaths = new List<GameObject>();
    private float spawnPositionX = 0f; // X position to spawn the next path segment

    void Start()
    {
        // Initialize the path by spawning the initial path segments
        for (int i = 0; i < initialPathCount; i++)
        {
            SpawnPath();
        }
    }

    void Update()
    {
        // Check if the player has passed the middle of the active paths list
        if (playerTransform.position.x > spawnPositionX - (pathLength * initialPathCount / 2))
        {
            SpawnPath();
            RemoveOldPath();
        }
    }

    void SpawnPath()
    {
        // Randomly select a path prefab to instantiate
        GameObject pathPrefab = pathPrefabs[Random.Range(0, pathPrefabs.Length)];
        GameObject newPath = Instantiate(pathPrefab, new Vector3(spawnPositionX, 0, 0), Quaternion.identity);

        // Add the new path to the active paths list
        activePaths.Add(newPath);

        // Update the spawn position for the next path segment
        spawnPositionX += pathLength;
    }

    void RemoveOldPath()
    {
        // Remove the oldest path segment from the active paths list and destroy it
        if (activePaths.Count > initialPathCount)
        {
            GameObject oldPath = activePaths[0];
            activePaths.RemoveAt(0);
            Destroy(oldPath);
        }
    }
}

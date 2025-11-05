using UnityEngine;

public class InfiniteSpawner : MonoBehaviour
{
    [Header("Prefabs to Spawn")]
    public GameObject objectToSpawn1; // First prefab
    public GameObject objectToSpawn2; // Second prefab

    [Header("Spawn Settings")]
    public Vector3 minRange = new Vector3(-10f, 0f, -10f);
    public Vector3 maxRange = new Vector3(10f, 5f, 10f);
    public float spawnInterval = 1f; // Time between spawns in seconds

    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // Pick a random position within the given range
        float x = Random.Range(minRange.x, maxRange.x);
        float y = Random.Range(minRange.y, maxRange.y);
        float z = Random.Range(minRange.z, maxRange.z);
        Vector3 randomPos = new Vector3(x, y, z);

        // Randomly choose which prefab to spawn
        GameObject prefabToSpawn = Random.value < 0.5f ? objectToSpawn1 : objectToSpawn2;

        // Make sure we have a prefab assigned before spawning
        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, randomPos, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Spawner tried to spawn, but one or both prefabs are missing!");
        }
    }
}

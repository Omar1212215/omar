using UnityEngine;

public class InfiniteSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The prefab to spawn
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

        // Spawn the object
        Instantiate(objectToSpawn, randomPos, Quaternion.identity);
    }
}

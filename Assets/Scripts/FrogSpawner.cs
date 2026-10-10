using UnityEngine;

public class FrogSpawner : MonoBehaviour
{
    public GameObject frogPrefab;
    public float spawnInterval = 0.8f;
    public float spawnY = 5f;
    public float minX = -6f;
    public float maxX = 6f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnFrog), 0f, spawnInterval);
    }

    private void SpawnFrog()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        Instantiate(frogPrefab, spawnPosition, Quaternion.identity);
    }
}
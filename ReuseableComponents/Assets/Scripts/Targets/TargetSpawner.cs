using UnityEngine;
using Random = UnityEngine.Random;

public class TargetSpawner : MonoBehaviour
{
    [Header("Target Spawning")]
    [SerializeField] private GameObject[] targetPrefabs;
    [SerializeField] private int startTargetCount = 5;
    
    [SerializeField] private Transform[] spawnPoints;

    private int activeTargetCount;

    private void Start()
    {
        SpawnInitialTargets();
    }

    private void SpawnInitialTargets()
    {
        for (int i = 0; i < startTargetCount; i++)
        {
            SpawnTarget();
        }
    }

    // Spawns a single target at a random spawn point
    public void SpawnTarget()
    {
        // Return if there are no prefabs or spawn points set
        if (targetPrefabs.Length == 0 || spawnPoints.Length == 0) return;
    
        // Select a random target prefab and spawn point
        GameObject prefab = targetPrefabs[Random.Range(0, targetPrefabs.Length)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
    
        // Instantiate the target and increment the active target count
        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        activeTargetCount++;
    }

    public void OnTargetDestroyed()
    {
        activeTargetCount--;
        SpawnTarget();
    }
}
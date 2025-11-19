using UnityEngine;
using System.Collections.Generic;

public class SpawnerManager : MonoBehaviour
{

    static public SpawnerManager Instance { get; private set; }

    // Create a Spawn Area
    [SerializeField] private Transform spawnAreaCenter;
    [SerializeField] private Vector3 spawnAreaSize;

    [Header("Prefab to Spawn")]
    [SerializeField] private GameObject prefabToSpawn;  
    [SerializeField] private List<GameObject> ghostList = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void OnDrawGizmosSelected()
    {
        if (spawnAreaCenter == null)
            return;

        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(spawnAreaCenter.position, spawnAreaSize);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(spawnAreaCenter.position, 0.1f);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnPrefab();
        }



    }

    public Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            0f,
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        return spawnAreaCenter.position + randomPosition;
    }

    public void SpawnPrefab()
    {
        Vector3 spawnPos = GetRandomSpawnPosition();
        Debug.Log("Spawn at: " + spawnPos);
        GameObject go = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
        ghostList.Add(go);
    }



}

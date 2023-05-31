using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 SpawnPos;
    public GameObject spawnObject;
    private float newSpawnDuration = 1f;

    #region Singleton

    public static SpawnManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    private void Start()
    {
        SpawnPos = transform.position;
    }
    
    void SpawnNewObject()
    {
        Instantiate(spawnObject, SpawnPos, Quaternion.identity);
    }
    
    public void NewSpawnRequest()
    {
        Invoke("SpawnNewObject", newSpawnDuration);
    }    
}


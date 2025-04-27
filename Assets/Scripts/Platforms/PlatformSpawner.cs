using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] protected Platform[] platforms;
    [SerializeField] protected Platform startPlatform;
    [SerializeField] protected int maxPlatformCount;
    [SerializeField] protected float platformLength;
    protected float _spawnerDirection;
    protected GameObject _objPlatforms;

    protected virtual void Start()
    {
        _objPlatforms = new GameObject();
        _objPlatforms.name = "Platforms";
    }

    void Update()
    {
        
    }

    protected Platform GetRandomPlatform()
    {
        int randomIndex = Random.Range(0, platforms.Length);
        return platforms[randomIndex];
    }

    protected virtual void SpawnPlatform(Platform spawnPlatform)
    {


        Instantiate(spawnPlatform, transform.forward * _spawnerDirection, transform.rotation, _objPlatforms.transform);
        _spawnerDirection += platformLength;
    }

    protected virtual void GenerateStart()
    {
        SpawnPlatform(startPlatform);
        for (int i = 0; i < maxPlatformCount; i++)
        { 
            SpawnPlatform(GetRandomPlatform());
        }
    }
}

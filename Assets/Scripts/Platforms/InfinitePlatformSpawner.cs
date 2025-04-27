using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePlatformSpawner : PlatformSpawner
{
    private Transform _playerTransform;
    private List<GameObject> _activePlatforms = new List<GameObject>();
    protected override void Start()
    {
        base.Start();
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
        GenerateStart();
    }
    void Update()
    {
        if (_playerTransform.position.z > _spawnerDirection - (maxPlatformCount * platformLength))
        {
            SpawnPlatform(GetRandomPlatform());
            RemoveActivePlatforms();
        }
    }

    protected override void SpawnPlatform(Platform spawnPlatform)
    {
        GameObject newPlatform = Instantiate(spawnPlatform,
                                            transform.forward * _spawnerDirection,
                                            transform.rotation,
                                            _objPlatforms.transform).gameObject;

        _spawnerDirection += platformLength;
        _activePlatforms.Add(newPlatform);
    }

    private void RemoveActivePlatforms()
    { 
        GameObject lostPlatform = _activePlatforms[0];
        _activePlatforms.RemoveAt(0);
        Destroy(lostPlatform);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitePlatformSpawner : PlatformSpawner
{
    [SerializeField] private int _maxCountToSpawnBustPlatform;
    [SerializeField] private Platform _bustPlatform;
    private int _countToSpawnBustPlatform;

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
            if (_countToSpawnBustPlatform >= _maxCountToSpawnBustPlatform)
            {
                SpawnPlatform(_bustPlatform);
                _countToSpawnBustPlatform = 0;
                return;
            }
            SpawnPlatform(GetRandomPlatform());
            _countToSpawnBustPlatform++;
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

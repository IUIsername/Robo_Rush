using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlatformSpawner : PlatformSpawner
{
    [SerializeField] private Platform finalPlatform;

    protected virtual void Start()
    {
        base.Start();
        GenerateStart();
    }

    protected override void GenerateStart()
    { 
        base.GenerateStart();
        SpawnPlatform(finalPlatform);
    }
}

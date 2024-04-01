using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsLite.Entities;
using UnityEngine;

[SerializeField]
public struct SpawnRequest
{
    public Entity prefab;
    public Vector3 position;
    public Quaternion rotation;
}

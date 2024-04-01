using System;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class SpawnRequestSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world = EcsWorldConstants.Events;
        private readonly EcsFilterInject<Inc<SpawnRequest>> _filter = EcsWorldConstants.Events;
        private readonly EcsCustomInject<EntityManager> _entityManager;

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            foreach (int ecsEvent in this._filter.Value)
            {
                SpawnRequest spawnRequest = this._filter.Pools.Inc1.Get(ecsEvent);
                Vector3 position = spawnRequest.position;
                Quaternion rotation = spawnRequest.rotation;
                Entity prefab = spawnRequest.prefab;

                this._entityManager.Value.Create(prefab, position, rotation);
                
                this._world.Value.DelEntity(ecsEvent);
            }
        }
    }
}
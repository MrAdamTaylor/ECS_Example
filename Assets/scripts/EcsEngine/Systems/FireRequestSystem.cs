using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    internal sealed class FireRequestSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<FireRequest, BulletWeapon>> _filter;
        private readonly EcsPoolInject<SpawnRequest> _spawnPool = EcsWorldConstants.Events;
        private readonly  EcsWorldInject _eventWorld = EcsWorldConstants.Events;
        

        void IEcsRunSystem.Run(IEcsSystems systems)
        {
            EcsPool<BulletWeapon> weaponPool = this._filter.Pools.Inc2;
            EcsPool<FireRequest> requestPool = this._filter.Pools.Inc1;

            foreach (int entity in this._filter.Value)
            {
                BulletWeapon bulletWeapon = weaponPool.Get(entity);
                Debug.Log($"Pew {bulletWeapon.bulletPrefab.name}");

                int spawnEvent = this._eventWorld.Value.NewEntity();
                this._spawnPool.Value.Add(spawnEvent) = new SpawnRequest
                {
                    position = bulletWeapon.firePoint.position,
                    rotation = bulletWeapon.firePoint.rotation,
                    prefab = bulletWeapon.bulletPrefab
                };
                
                Debug.Log($"Spawn {bulletWeapon.bulletPrefab.name}");
                requestPool.Del(entity);
            }
        }
    }
}
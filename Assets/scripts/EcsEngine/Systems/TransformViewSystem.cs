using System;
using EcsEngine.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsEngine.Systems
{
    public class TransformViewSystem : IEcsPostRunSystem
    {
        /// <summary>
        /// Этот вызово - это внедрение зависимости
        /// </summary>
        private readonly EcsFilterInject<Inc<TransformView, Position>> _filetr;

        private readonly EcsPoolInject<Rotation> _rotationPool;

        public void PostRun(IEcsSystems systems)
        {
            Debug.Log("View System");

            EcsPool<Rotation> rotationPool = this._rotationPool.Value;

            foreach (int entity in this._filetr.Value)
            {
                ref TransformView transform = ref this._filetr.Pools.Inc1.Get(entity);
                Position position = this._filetr.Pools.Inc2.Get(entity);
                transform.value.position = position.value;

                
                if (rotationPool.Has(entity))
                {
                    Quaternion rotation = rotationPool.Get(entity).value;
                    transform.value.rotation = rotation;
                }
            }
        }
    }
}
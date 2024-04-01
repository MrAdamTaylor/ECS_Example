using System.Collections;
using System.Collections.Generic;
using EcsEngine.Components;
using Leopotam.EcsLite.Entities;
using UnityEngine;

public class CharacterInstaller : EntityInstaller
{
        [SerializeField] private Transform _firePoint;

        [SerializeField] private Entity _bulletPrefab;
        protected override void Install(Entity entity)
        {
            entity.AddData(new Position{value = this.transform.position});
            entity.AddData(new Rotation {value = this.transform.rotation});
            entity.AddData(new MoveDirection{value = Vector3.forward});
            entity.AddData(new MoveSpeed{value = 5});
            entity.AddData(new BulletWeapon
            {
                firePoint =  _firePoint,
                bulletPrefab = _bulletPrefab
            });
            entity.AddData(new TransformView{value = this.transform});
        }

        protected override void Dispose(Entity entity)
        {
            
        }
}

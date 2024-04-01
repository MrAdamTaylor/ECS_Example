using System;
using EcsEngine.Components;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Content
{
    internal sealed class CharecterMoveController : MonoBehaviour
    {
        [SerializeField] private Entity character;
        [SerializeField] private MoveInput input;

        private void Update()
        {
            Vector3 inputDirection = this.input.GetDirection();
            ref MoveDirection moveDirection = ref this.character.GetData<MoveDirection>();
            moveDirection.value = inputDirection;
        }
    }
}
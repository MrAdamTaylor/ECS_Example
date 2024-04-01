using EcsEngine.Components;
using GameSystem;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Content
{
    public class CharacterFireController : MonoBehaviour
    {
        [SerializeField] private Entity character;

        [SerializeField] private FireInput fireInput;

        private void Update()
        {
            if (this.fireInput.IsFirePressDown())
            {
                this.character.SetData(new FireRequest());
            }
        }
    }
}
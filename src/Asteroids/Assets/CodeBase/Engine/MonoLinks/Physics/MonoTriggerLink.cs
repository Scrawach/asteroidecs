using CodeBase.Core.Gameplay.Components.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Engine.MonoLinks.Physics
{
    [RequireComponent(typeof(Collider2D))]
    public class MonoTriggerLink : PhysicsLinkBase
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out MonoTriggerLink link))
            {
                Entity.Get<OnTriggerEnter>() = new OnTriggerEnter
                {
                    Sender = Entity,
                    Trigger = link.Entity
                };
            }
        }
    }
}
using CodeBase.Core.Gameplay.Components.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Engine.MonoLinks.Physics
{
    [RequireComponent(typeof(Collider2D))]
    public class MonoCollisionLink : PhysicsLinkBase
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out MonoCollisionLink link))
            {
                Entity.Get<OnCollisionEnter>() = new OnCollisionEnter
                {
                    Sender = Entity,
                    Collision = link.Entity
                };
            }
        }
    }
}
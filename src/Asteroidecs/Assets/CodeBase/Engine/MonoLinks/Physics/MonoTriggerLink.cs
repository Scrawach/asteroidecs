using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components.Events;
using Leopotam.EcsLite;
using UnityEngine;

namespace CodeBase.Engine.MonoLinks.Physics
{
    [RequireComponent(typeof(Collider2D))]
    public class MonoTriggerLink : PhysicsLinkBase
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out MonoTriggerLink link))
                World.NewEntityWith(new OnTriggerEnterRequest
                {
                    Sender = World.PackEntity(Entity),
                    Trigger = World.PackEntity(link.Entity)
                });
        }
    }
}
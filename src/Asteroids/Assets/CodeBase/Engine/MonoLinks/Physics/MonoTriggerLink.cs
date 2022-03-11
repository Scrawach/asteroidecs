using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components.Events;
using UnityEngine;

namespace CodeBase.Engine.MonoLinks.Physics
{
    [RequireComponent(typeof(Collider2D))]
    public class MonoTriggerLink : PhysicsLinkBase
    {
        private bool _alwaysRegistered;

        private void FixedUpdate() => _alwaysRegistered = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out MonoTriggerLink link))
            {
                if (link._alwaysRegistered)
                    return;

                _alwaysRegistered = true;


                World.NewEntityWith(new OnTriggerEnter
                {
                    Sender = Entity,
                    Trigger = link.Entity
                });
            }
        }
    }
}
using CodeBase.Core.Gameplay.Components.Weapon;
using CodeBase.Engine.MonoLinks.Base;
using Leopotam.EcsLite;
using UnityEngine;

namespace CodeBase.Engine.MonoLinks
{
    public class MonoReloadView : MonoLinkBase
    {
        public Transform View;
        public float ReloadedValueScale = 0.9f;
        public float WhenEmptyPosition = -0.1151f;

        private EcsPackedEntityWithWorld _entityWithWorld;

        public override void Resolve(EcsWorld world, int entity)
        {
            _entityWithWorld = world.PackEntityWithWorld(entity);
            ResetProgressBar();
        }

        private void Update() =>
            UpdateProgressBar();

        private void UpdateProgressBar()
        {
            if (_entityWithWorld.Unpack(out var world, out var entity))
            {
                var reloads = world.GetPool<LaserReload>();
                
                if (reloads.Has(entity))
                {
                    var reload = reloads.Get(entity);
                    ApplyProgress(1 - reload.ElapsedCooldown / reload.Cooldown);
                }
            }
        }

        private void ResetProgressBar()
        {
            const float full = 1;
            ApplyProgress(full);
        }

        private void ApplyProgress(float percents)
        {
            var scale = View.localScale;
            scale.x = ReloadedValueScale * percents;
            View.localScale = scale;

            var position = View.localPosition;
            position.x = Mathf.Lerp(WhenEmptyPosition, 0f, percents);
            View.localPosition = position;
        }
    }
}
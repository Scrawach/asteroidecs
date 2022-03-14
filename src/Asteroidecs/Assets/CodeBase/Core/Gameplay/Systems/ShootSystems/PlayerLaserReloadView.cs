using CodeBase.Core.Gameplay.Components.Weapon;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.ShootSystems
{
    public class PlayerLaserReloadView : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world
                .Filter<LaserReload>()
                .Inc<ReloadView>()
                .End();

            var views = world.GetPool<ReloadView>();
            var reloads = world.GetPool<LaserReload>();

            foreach (var index in filter)
            {
                ref var view = ref views.Get(index);
                ref var reload = ref reloads.Get(index);
                view.View.ApplyProgress(1 - reload.ElapsedCooldown / reload.Cooldown);
            }
        }
    }
}
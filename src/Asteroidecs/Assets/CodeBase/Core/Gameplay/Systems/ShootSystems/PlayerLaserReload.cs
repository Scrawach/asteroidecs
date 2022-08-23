using CodeBase.Core.Gameplay.Components.Weapon;
using CodeBase.Core.Gameplay.Services.Time;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.ShootSystems
{
    public class PlayerLaserReload : IEcsRunSystem
    {
        private readonly ITime _time;

        public PlayerLaserReload(ITime time) =>
            _time = time;

        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<LaserReload>().End();
            var reloads = world.GetPool<LaserReload>();

            foreach (var index in filter)
            {
                ref var reload = ref reloads.Get(index);
                reload.ElapsedCooldown -= _time.DeltaFrame;

                if (reload.ElapsedCooldown <= 0)
                    reloads.Del(index);
            }
        }
    }
}
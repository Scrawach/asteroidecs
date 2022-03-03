using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems.LifecycleSystems
{
    public class LifecycleSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Lifetime> _lives = default;
        private readonly ITime _time = default;
        
        public void Run()
        {
            foreach (var index in _lives)
            {
                ref var life = ref _lives.Get1(index);
                life.Time -= _time.DeltaFrame;

                if (life.Time <= 0) 
                    _lives.GetEntity(index).Get<DestroyTag>();
            }
        }
    }
}
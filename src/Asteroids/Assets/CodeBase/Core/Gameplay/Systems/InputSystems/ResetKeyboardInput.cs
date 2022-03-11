using CodeBase.Core.Gameplay.Components.Tags;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.InputSystems
{
    public class ResetKeyboardInput : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<FireButtonPressedTag>().End();
            var pool = world.GetPool<FireButtonPressedTag>();
            foreach (var index in filter)
                world.DelEntity(index);
        }
    }
}
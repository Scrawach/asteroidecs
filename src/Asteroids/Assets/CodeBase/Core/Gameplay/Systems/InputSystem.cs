using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using Leopotam.Ecs;

namespace CodeBase.Core.Gameplay.Systems
{
    public class InputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = default;
        private readonly IInput _input = default;

        public void Run()
        {
            if (_input.IsFireButtonPressed() == false)
                return;

            var entity = _world.NewEntity();
            entity.Get<FireButtonPressedTag>();
        }
    }
}
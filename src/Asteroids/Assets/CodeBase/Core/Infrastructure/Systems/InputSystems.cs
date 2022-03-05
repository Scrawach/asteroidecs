using CodeBase.Core.Gameplay.Components.Tags;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Systems.InputSystems;
using Leopotam.Ecs;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class InputSystems : ISystemBuilder
    {
        private readonly IInput _input;

        public InputSystems(IInput input) => 
            _input = input;

        public EcsSystems Build(EcsWorld world) =>
            new EcsSystems(world, nameof(InputSystems))
                .OneFrame<FireButtonPressedTag>()
                .Add(new KeyboardInputSystem(_input))
                .Add(new MouseInputSystem(_input));
    }
}
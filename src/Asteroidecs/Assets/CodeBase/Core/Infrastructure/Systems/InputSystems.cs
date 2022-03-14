using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components.Events;
using CodeBase.Core.Gameplay.Services;
using CodeBase.Core.Gameplay.Systems.InputSystems;
using CodeBase.Core.Infrastructure.Systems.Abstract;
using Leopotam.EcsLite;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class InputSystems : IConnectableSystem
    {
        private readonly IInput _input;

        public InputSystems(IInput input) =>
            _input = input;

        public EcsSystems ConnectTo(EcsSystems systems) =>
            systems
                .DeleteHere<FireButtonPressedEvent>()
                .DeleteHere<LaserButtonPressedEvent>()
                .Add(new KeyboardInputSystem(_input))
                .Add(new MouseInputSystem(_input));
    }
}
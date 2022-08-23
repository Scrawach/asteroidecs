using CodeBase.Core.Gameplay.Systems.AiSystems;
using CodeBase.Core.Infrastructure.Systems.Abstract;
using Leopotam.EcsLite;

namespace CodeBase.Core.Infrastructure.Systems
{
    public class AiSystems : IConnectableSystem
    {
        public IEcsSystems ConnectTo(IEcsSystems systems) =>
            systems
                .Add(new FindTargetForAliens())
                .Add(new FollowTargetSystem());
    }
}
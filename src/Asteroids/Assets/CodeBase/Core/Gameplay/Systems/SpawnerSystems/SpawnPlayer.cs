using CodeBase.Core.Common;
using CodeBase.Core.Extensions;
using CodeBase.Core.Gameplay.Components;
using Leopotam.EcsLite;

namespace CodeBase.Core.Gameplay.Systems.SpawnerSystems
{
    public class SpawnPlayer : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            var world = systems.GetWorld();
            world.NewEntityWith(new SpawnInfo(ObjectId.Player, new Vector2Data(0, 0), new Vector2Data(0, 1)));
        }
    }
}
using CodeBase.Core.Gameplay.Systems.Common;
using Leopotam.EcsLite;

namespace CodeBase.Core.Extensions
{
    public static class EcsSystemsExtensions
    {
        public static EcsSystems DeleteHere<TComponent>(this EcsSystems systems) where TComponent : struct =>
            systems.Add(new DeleteHere<TComponent>());
    }
}
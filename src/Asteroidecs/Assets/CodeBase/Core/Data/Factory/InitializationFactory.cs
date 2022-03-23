using System.Threading.Tasks;
using CodeBase.Core.Common;
using CodeBase.Core.Data.Abstract;
using CodeBase.Core.Data.Applies;
using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Services;
using Leopotam.EcsLite;

namespace CodeBase.Core.Data.Factory
{
    public class InitializationFactory : IFactory
    {
        private readonly IApplyConfigValue[] _assumptionsApplies;
        private readonly IObjectConfigs _configs;
        private readonly IFactory _instFactory;

        public InitializationFactory(IFactory instFactory, IObjectConfigs configs)
        {
            _instFactory = instFactory;
            _configs = configs;
            _assumptionsApplies = new IApplyConfigValue[]
            {
                new ApplyMovementSpeed(configs),
                new ApplyAcceleration(configs),
                new ApplyHealth(configs),
                new ApplyBonusForDestruction(configs),
                new ApplyDamageOnCollide(configs)
            };
        }

        public async Task<int> Create(SpawnInfo info, EcsWorld world)
        {
            var instance = await _instFactory.Create(info, world);
            if (_configs.HasConfig(info.Id))
                SetConfigValues(instance, info.Id, world);
            return instance;
        }

        private void SetConfigValues(int entity, ObjectId objectId, EcsWorld world)
        {
            foreach (var piece in _assumptionsApplies)
                piece.TryApply(entity, world, objectId);
        }
    }
}
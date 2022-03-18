using System.Collections.Generic;
using CodeBase.Core.Common;

namespace CodeBase.Core.Data
{
    public class ConstantConfigService : IConfigService
    {
        private readonly Dictionary<ObjectId, ObjectConfig> _data;

        public ConstantConfigService() =>
            _data = new Dictionary<ObjectId, ObjectConfig>
            {
                [ObjectId.Player] = new ObjectConfig
                {
                    Health = 10,
                    MovementSpeed = 6,
                    Acceleration = 2
                },
                [ObjectId.Asteroid] = new ObjectConfig
                {
                    MovementSpeed = 1,
                    BonusForDestruction = 1,
                    DamageOnCollide = 2
                },
                [ObjectId.Alien] = new ObjectConfig
                {
                    MovementSpeed = 4,
                    BonusForDestruction = 5,
                    DamageOnCollide = 2
                }
            };

        public bool HasConfig(ObjectId id) =>
            _data.ContainsKey(id);

        public ObjectConfig Get(ObjectId id) =>
            _data[id];
    }
}
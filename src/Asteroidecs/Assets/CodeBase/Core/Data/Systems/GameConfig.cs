using System.Collections.Generic;
using CodeBase.Core.Common;

namespace CodeBase.Core.Data.Systems
{
    public class GameConfig : ISpawnConfig
    {
        public float AsteroidCooldown { get; set; }
        public float AlienCooldown { get; set; }
        
        public Dictionary<ObjectId, ObjectConfig> Objects { get; set; }
    }
}
using System.Collections.Generic;
using CodeBase.Core.Common;

namespace CodeBase.Core.Data
{
    public class ConfigService : IConfigService
    {
        private readonly Dictionary<ObjectId, ObjectConfig> _data;

        public ConfigService(Dictionary<ObjectId, ObjectConfig> data) =>
            _data = data;

        public bool HasConfig(ObjectId id) =>
            _data.ContainsKey(id);

        public ObjectConfig Get(ObjectId id) =>
            _data[id];
    }
}
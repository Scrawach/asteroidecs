using System.Collections.Generic;
using CodeBase.Core.Common;
using CodeBase.Core.Data;
using CodeBase.Engine.Services.AssetManagement;
using Newtonsoft.Json;
using UnityEngine;

namespace CodeBase.Engine.Services.Configs
{
    public class JsonConfigService : IConfigService
    {
        private const string Address = "Configs";
        private readonly IAssets _assets;
        private Dictionary<ObjectId, ObjectConfig> _data;

        public JsonConfigService(IAssets assets) =>
            _assets = assets;

        public async void Load()
        {
            var asset = await _assets.Load<TextAsset>(Address);
            _data = JsonConvert.DeserializeObject<Dictionary<ObjectId, ObjectConfig>>(asset.text);
        }

        public bool HasConfig(ObjectId id) =>
            _data.ContainsKey(id);

        public ObjectConfig Get(ObjectId id) =>
            _data[id];
    }
}
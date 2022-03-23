using System;
using System.Threading.Tasks;
using CodeBase.Core;
using CodeBase.Core.Common;
using CodeBase.Core.Data;
using CodeBase.Core.Data.Systems;
using CodeBase.Engine.Services.AssetManagement;
using Newtonsoft.Json;
using UnityEngine;

namespace CodeBase.Engine.Services.Configs
{
    public class JsonConfig : IObjectConfigs, ISpawnConfig, ILoadingResource
    {
        private const string Address = "Configs";
        private readonly IAssets _assets;
        private GameConfig _gameConfig;

        public JsonConfig(IAssets assets) =>
            _assets = assets;

        public float AsteroidCooldown { get; private set; } = float.MaxValue;
        public float AlienCooldown { get; private set; } = float.MaxValue;

        public async Task Load()
        {
            var asset = await _assets.Load<TextAsset>(Address);
            _gameConfig = JsonConvert.DeserializeObject<GameConfig>(asset.text);

            if (_gameConfig == null)
                throw new NullReferenceException("Game config can not loaded!");
            
            AsteroidCooldown = _gameConfig.AsteroidCooldown;
            AlienCooldown = _gameConfig.AlienCooldown;
        }

        public bool HasConfig(ObjectId id) =>
            _gameConfig.Objects.ContainsKey(id);

        public ObjectConfig Get(ObjectId id) =>
            _gameConfig.Objects[id];
    }
}
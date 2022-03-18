﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CodeBase.Core;
using CodeBase.Core.Common;
using CodeBase.Core.Data;
using CodeBase.Core.Data.Factory;
using CodeBase.Core.Gameplay.Components;
using CodeBase.Core.Gameplay.Services.Meta;
using CodeBase.Core.Gameplay.Services.Time;
using CodeBase.Core.Infrastructure.Systems;
using CodeBase.Engine.Services;
using CodeBase.Engine.Services.AssetManagement;
using CodeBase.Engine.Services.AssetManagement.Pool;
using CodeBase.Engine.Services.CameraLogic;
using CodeBase.Engine.Services.Factory;
using CodeBase.Engine.Systems;
using Leopotam.EcsLite;
using UnityEngine;

namespace CodeBase
{
    public static class EntryPoint
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static async void Main() =>
            await GameLoop(NewGame(Camera.main));
        //Test();

        private static void Test()
        {
            Debug.Log("START TEST");
            var assets = new Assets();
            var factory = new GameFactory(assets);

            var configs = new ConfigService(new Dictionary<ObjectId, ObjectConfig>
            {
                [ObjectId.Player] = new ObjectConfig {MovementSpeed = 10}
            });

            var initFactory = new InitializationFactory(factory, configs);

            initFactory.Create(
                new SpawnInfo(ObjectId.Player, new Vector2Data(0, 0), new Vector2Data(0, 0)),
                new EcsWorld());
        }

        private static async Task GameLoop(Game game)
        {
            game.Start();
            while (game.IsPlaying)
            {
                game.Update();
                await Task.Yield();
            }
        }

        private static Game NewGame(Camera mainCamera)
        {
            var assets = new PoolAssets(new Assets());
            var wallet = new WalletService();
            var time = new WatchTime();
            var random = new UnityRandom(0);

            var input = new UnityInput(mainCamera);
            var gameScreen = new CameraGameScreen(mainCamera);

            var configs = new ConfigService(DefaultConfig());

            var factory = new InitializationFactory(new GameFactory(assets), configs);
            var uiFactory = new UiFactory(assets, wallet);

            var config = new GameConfig();

            var game = new Game
            (
                new UpdateTimeSystems(time),
                new InputSystems(input),
                new MovementSystems(gameScreen, time),
                new SpawnSystems(factory, gameScreen, time, random, config),
                new AiSystems(),
                new ShootSystems(time),
                new PhysicSystems(),
                new LifecycleSystems(time, gameScreen),
                new MetaSystems(wallet, uiFactory),
                new CleanUpSystems(),
                new DebugSystems()
            );

            Application.quitting += () => game.Quit();
            return game;
        }

        private static Dictionary<ObjectId, ObjectConfig> DefaultConfig() =>
            new Dictionary<ObjectId, ObjectConfig>
            {
                [ObjectId.Player] = new ObjectConfig
                {
                    Health = 10,
                    MovementSpeed = 5,
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
    }
}
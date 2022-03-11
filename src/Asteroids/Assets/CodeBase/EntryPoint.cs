using System.Threading.Tasks;
using CodeBase.Core;
using CodeBase.Core.Gameplay.Services.Meta;
using CodeBase.Core.Infrastructure.Systems;
using CodeBase.Engine.Services;
using CodeBase.Engine.Services.AssetManagement;
using CodeBase.Engine.Services.CameraLogic;
using CodeBase.Engine.Services.Factory;
using Leopotam.EcsLite;
using UnityEngine;

namespace CodeBase
{
    public static class EntryPoint
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static async void Main() =>
            await GameLoop(NewGame(Camera.main));

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
            var ecsWorld = new EcsWorld();
            var assets = new Assets();
            var wallet = new WalletService();
            var time = new UnityTime();
            var random = new UnityRandom(0);

            var input = new UnityInput(mainCamera);
            var gameScreen = new CameraGameScreen(mainCamera);

            var factory = new GameFactory(assets);
            var restartService = new RestartService(ecsWorld);
            var uiFactory = new UiFactory(assets, wallet, restartService);

            var game = new Game
            (
                ecsWorld,
                new InputSystems(input),
                new MovementSystems(gameScreen, time),
                new SpawnSystems(factory, gameScreen, time, random),
                new ShootSystems(),
                new PhysicSystems(),
                new MetaSystems(wallet, uiFactory),
                new LifecycleSystems(time, gameScreen)
            );

            Application.quitting += () => game.Quit();

            return game;
        }
    }
}
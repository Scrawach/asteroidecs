using System.Threading.Tasks;
using CodeBase.Core;
using CodeBase.Core.Gameplay.Services.Meta;
using CodeBase.Core.Infrastructure.Systems;
using CodeBase.Engine.Services;
using CodeBase.Engine.Services.AssetManagement;
using CodeBase.Engine.Services.AssetManagement.Pool;
using CodeBase.Engine.Services.CameraLogic;
using CodeBase.Engine.Services.Factory;
using CodeBase.Engine.Systems;
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
            var assets = new PoolAssets(new Assets());
            var wallet = new WalletService();
            var time = new UnityTime();
            var random = new UnityRandom(0);

            var input = new UnityInput(mainCamera);
            var gameScreen = new CameraGameScreen(mainCamera);

            var factory = new GameFactory(assets);
            var uiFactory = new UiFactory(assets, wallet);

            var game = new Game
            (
                new InputSystems(input),
                new MovementSystems(gameScreen, time),
                new SpawnSystems(factory, gameScreen, time, random),
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
    }
}
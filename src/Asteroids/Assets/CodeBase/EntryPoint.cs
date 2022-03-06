using System.Threading.Tasks;
using CodeBase.Core;
using CodeBase.Core.Gameplay.Services.Meta;
using CodeBase.Engine.Services;
using CodeBase.Engine.Services.AssetManagement;
using CodeBase.Engine.Services.CameraLogic;
using CodeBase.Engine.Services.Factory;
using UnityEngine;

namespace CodeBase
{
    public static class EntryPoint
    {
        private static bool _playing = true;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static async void Main()
        {
            Application.quitting += () => _playing = false;
            await GameLoop(NewGame(Camera.main));
        }

        private static Game NewGame(Camera mainCamera)
        {
            var wallet = new WalletService();
            var factory = new GameFactory(new Assets(), wallet);
            factory.CreateHud();
            
            return new Game
            (
                new UnityInput(mainCamera),
                factory,
                new UnityTime(),
                new UnityDebug(),
                new CameraGameScreen(mainCamera),
                new UnityRandom(),
                wallet
            );
        }

        private static async Task GameLoop(Game game)
        {
            game.Start();
            while (_playing)
            {
                game.Update();
                await Task.Yield();
            }
        }
    }
}

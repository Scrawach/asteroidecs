using CodeBase.Core;
using CodeBase.Engine.Services;
using CodeBase.Engine.Services.AssetManagement;
using CodeBase.Engine.Services.CameraLogic;
using CodeBase.Engine.Services.Factory;
using UnityEngine;

namespace CodeBase.Engine
{
    public class GameBootstrapper : MonoBehaviour
    {
        private Game _game;
        
        private void Awake()
        {
            var mainCamera = Camera.main;

            _game = new Game
            (
                new UnityInput(mainCamera), 
                new GameFactory(new Assets()), 
                new UnityTime(), 
                new UnityDebug(), 
                new CameraGameScreen(mainCamera),
                new UnityRandom()
            );
        }

        private void Start() => 
            _game.Start();

        private void Update() => 
            _game.Update();
    }
}

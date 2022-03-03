using System;
using CodeBase.Core;
using CodeBase.Engine.Services;
using CodeBase.Engine.Services.AssetManagement;
using UnityEngine;

namespace CodeBase.Engine
{
    public class GameBootstrapper : MonoBehaviour
    {
        public UnityInput Input;

        private Game _game;
        
        private void Awake() => 
            _game = new Game(Input, new GameFactory(new Assets()), new UnityTime(), new UnityDebug());

        private void Start() => 
            _game.Start();

        private void Update() => 
            _game.Update();
    }
}

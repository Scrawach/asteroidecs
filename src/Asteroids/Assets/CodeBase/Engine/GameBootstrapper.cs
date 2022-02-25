using System;
using CodeBase.Core;
using CodeBase.Engine.Services;
using UnityEngine;

namespace CodeBase.Engine
{
    public class GameBootstrapper : MonoBehaviour
    {
        public UnityInput Input;
        public GameFactory Factory;
        
        private Game _game;
        
        private void Awake() => 
            _game = new Game(Input, Factory);

        private void Start() => 
            _game.Start();

        private void Update() => 
            _game.Update();
    }
}

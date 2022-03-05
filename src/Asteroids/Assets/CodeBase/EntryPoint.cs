﻿using System.Threading.Tasks;
using CodeBase.Core;
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

        private static Game NewGame(Camera mainCamera) =>
            new Game
            (
                new UnityInput(mainCamera), 
                new GameFactory(new Assets()), 
                new UnityTime(), 
                new UnityDebug(), 
                new CameraGameScreen(mainCamera),
                new UnityRandom()
            );

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

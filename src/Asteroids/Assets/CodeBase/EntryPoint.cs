using System.Threading.Tasks;
using CodeBase.Core;
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
            await GameLoop(new Game());
        }

        private static async Task GameLoop(Game game)
        {
            game.Start();
            while (_playing)
            {
                game.Update(10);
                await Task.Yield();
            }
        }
    }
}

using System.Diagnostics;

namespace CodeBase.Core.Gameplay.Services.Time
{
    public class WatchTime : ITime
    {
        private readonly Stopwatch _watch;

        public WatchTime() =>
            _watch = new Stopwatch();

        public float Elapsed { get; private set; }
        public float DeltaFrame { get; private set; }

        public void Start() =>
            _watch.Start();

        public void Update()
        {
            var elapsedInSeconds = _watch.ElapsedMilliseconds / 1000f;
            DeltaFrame = elapsedInSeconds - Elapsed;
            Elapsed = elapsedInSeconds;
        }

        public void Stop() =>
            _watch.Stop();

        public void Reset()
        {
            _watch.Reset();
            Elapsed = 0;
            DeltaFrame = 0;
        }
    }
}
using CodeBase.Engine.MonoLinks;
using CodeBase.Engine.Services.Factory;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Engine.Components
{
    public class SpawnAfterDestroy : MonoBehaviour
    {
        [SerializeField] private AssetReferenceGameObject _reference;

        private MonoDestroyable _destroyable;
        private GameFactory _factory;
        private EcsWorld _world;

        public void Construct(GameFactory factory, EcsWorld world)
        {
            _factory = factory;
            _world = world;
        }

        private void Awake() =>
            _destroyable = GetComponent<MonoDestroyable>();

        private void OnEnable() =>
            _destroyable.Destroyed += OnDestroyed;

        private void OnDisable() =>
            _destroyable.Destroyed -= OnDestroyed;

        private async void OnDestroyed() =>
            await _factory.Create(_reference, transform.position, Quaternion.identity, _world);
    }
}
using CodeBase.Core.Gameplay.Components.Lifecycle;
using CodeBase.Engine.MonoLinks;
using UnityEngine;

namespace CodeBase.Engine.Components
{
    [RequireComponent(typeof(IDestroyable))]
    public class SpawnAfterDestroy : MonoBehaviour
    {
        [SerializeField]
        private GameObject _template;

        private MonoDestroyable _destroyable;
        
        private void Awake() => 
            _destroyable = GetComponent<MonoDestroyable>();

        private void OnEnable() => 
            _destroyable.Destroyed += OnDestroyed;

        private void OnDisable() => 
            _destroyable.Destroyed -= OnDestroyed;

        private void OnDestroyed() => 
            Instantiate(_template, transform.position, Quaternion.identity);
    }
}
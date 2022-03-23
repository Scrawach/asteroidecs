using CodeBase.Engine.MonoLinks;
using UnityEngine;

namespace CodeBase.Engine.Components
{
    [RequireComponent(typeof(MonoDestroyable))]
    public class ResetViewAfterDestroy : MonoBehaviour
    {
        private MonoDestroyable _destroyable;
        
        [SerializeField]
        private LaserReloadView _laserReloadView;

        private void Awake() =>
            _destroyable = GetComponent<MonoDestroyable>();

        private void OnEnable() =>
            _destroyable.Destroyed += OnDestroyed;

        private void OnDisable() =>
            _destroyable.Destroyed -= OnDestroyed;

        private void OnDestroyed()
        {
            const float full = 1;
            _laserReloadView.ApplyProgress(full);
        }
    }
}
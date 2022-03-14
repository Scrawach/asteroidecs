using UnityEngine;

namespace CodeBase.Engine.Components
{
    public class DestroyAfter : MonoBehaviour
    {
        [SerializeField] private float _timeInSeconds;

        private void Awake() =>
            Destroy(gameObject, _timeInSeconds);
    }
}
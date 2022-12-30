using Leopotam.EcsLite;
using UnityEngine;

namespace CodeBase.Engine.MonoLinks.Base
{
    public abstract class MonoLinkBase : MonoBehaviour
    {
        public abstract void Resolve(EcsWorld world, int entity);
    }
}
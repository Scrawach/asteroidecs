using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Engine.MonoLinks.Base
{
    public abstract class MonoLinkBase : MonoBehaviour
    {
        public abstract void Resolve(ref EcsEntity entity);
    }
}
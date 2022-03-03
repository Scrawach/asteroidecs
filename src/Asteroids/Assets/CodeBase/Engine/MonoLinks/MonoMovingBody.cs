using CodeBase.Core.Common;
using CodeBase.Core.Gameplay.Components.Moves;
using CodeBase.Engine.Common;
using CodeBase.Engine.MonoLinks.Base;
using Leopotam.Ecs;
using Vector3 = UnityEngine.Vector3;

namespace CodeBase.Engine.MonoLinks
{
    public class MonoMovingBody : MonoLink<MovingBody>, IBody
    {
        public override void Resolve(ref EcsEntity entity)
        {
            Value = new MovingBody { Body = this };
            base.Resolve(ref entity);
        }

        public void Move(Vector2Data movement)
        {
            var worldPoint = new Vector3(movement.X, movement.Y, 0f);
            //var direction = worldPoint - transform.position;
            transform.position = worldPoint;
            //transform.Translate(direction);
        }

        public void Rotate(Vector2Data direction) => 
            transform.rotation = direction.ToQuaternion();
    }
}
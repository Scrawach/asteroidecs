using CodeBase.Core.Common;
using CodeBase.Core.Gameplay.Components;
using CodeBase.Engine.MonoLinks.Base;
using Leopotam.Ecs;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
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

        public Vector2Data Position =>
            new Vector2Data(transform.position.x, transform.position.y);

        public void Move(Vector2Data movement)
        {
            var worldPoint = new Vector3(movement.X, movement.Y, 0f);
            //var direction = worldPoint - transform.position;
            transform.position = worldPoint;
            //transform.Translate(direction);
        }

        public void Rotate(float angle) => 
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
using Leopotam.Ecs;

namespace CodeBase.Engine.MonoLinks.Base
{
    public class MonoEntity : MonoLinkBase
    {
        private EcsEntity _entity;
        private MonoLinkBase[] _links;
        
        public override void Resolve(ref EcsEntity entity)
        {
            _links = GetComponents<MonoLinkBase>();
            foreach (var link in _links)
            {
                if (link is MonoEntity)
                    continue;
                
                link.Resolve(ref entity);
            }
        }
    }
}
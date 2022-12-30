using Leopotam.EcsLite;

namespace CodeBase.Engine.MonoLinks.Base
{
    public class MonoEntity : MonoLinkBase
    {
        private MonoLinkBase[] _links;

        public override void Resolve(EcsWorld world, int entity)
        {
            _links = GetComponents<MonoLinkBase>();
            foreach (var link in _links)
            {
                if (link is MonoEntity)
                    continue;

                link.Resolve(world, entity);
            }
        }
    }
}
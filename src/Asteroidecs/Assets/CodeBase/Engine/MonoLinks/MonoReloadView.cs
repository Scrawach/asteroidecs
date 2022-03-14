using CodeBase.Core.Gameplay.Components.Weapon;
using CodeBase.Engine.Components;
using CodeBase.Engine.MonoLinks.Base;
using Leopotam.EcsLite;

namespace CodeBase.Engine.MonoLinks
{
    public class MonoReloadView : MonoLink<ReloadView>
    {
        public LaserReloadView ReloadView;

        public override void Resolve(EcsWorld world, int entity)
        {
            Value = new ReloadView {View = ReloadView};
            base.Resolve(world, entity);
        }
    }
}
using CodeBase.Core.Data.Abstract;
using CodeBase.Core.Gameplay.Components.Lifecycle;

namespace CodeBase.Core.Data.Applies
{
    public class ApplyDamageOnCollide : ApplyConfigValue<DamageOnCollide>
    {
        public ApplyDamageOnCollide(IConfigService configs) : base(configs) { }

        protected override bool OnHasValue(ObjectConfig config) =>
            config.DamageOnCollide.HasValue;

        protected override void OnApply(ref DamageOnCollide component, ObjectConfig config) =>
            // ReSharper disable once PossibleInvalidOperationException
            component.Value = config.DamageOnCollide.Value;
    }
}
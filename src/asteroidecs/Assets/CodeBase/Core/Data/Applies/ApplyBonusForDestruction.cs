using CodeBase.Core.Data.Abstract;
using CodeBase.Core.Gameplay.Components.Meta;

namespace CodeBase.Core.Data.Applies
{
    public class ApplyBonusForDestruction : ApplyConfigValue<BonusForDestruction>
    {
        public ApplyBonusForDestruction(IObjectConfigs configs) : base(configs) { }

        protected override bool OnHasValue(ObjectConfig config) =>
            config.BonusForDestruction.HasValue;

        protected override void OnApply(ref BonusForDestruction component, ObjectConfig config) =>
            // ReSharper disable once PossibleInvalidOperationException
            component.Value = config.BonusForDestruction.Value;
    }
}
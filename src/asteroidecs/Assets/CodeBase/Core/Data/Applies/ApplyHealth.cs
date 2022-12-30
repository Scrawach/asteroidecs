using CodeBase.Core.Data.Abstract;
using CodeBase.Core.Gameplay.Components.Lifecycle;

namespace CodeBase.Core.Data.Applies
{
    public class ApplyHealth : ApplyConfigValue<Health>
    {
        public ApplyHealth(IObjectConfigs configs) : base(configs) { }

        protected override bool OnHasValue(ObjectConfig config) =>
            config.Health.HasValue;

        protected override void OnApply(ref Health component, ObjectConfig config) =>
            // ReSharper disable once PossibleInvalidOperationException
            component.Value = config.Health.Value;
    }
}
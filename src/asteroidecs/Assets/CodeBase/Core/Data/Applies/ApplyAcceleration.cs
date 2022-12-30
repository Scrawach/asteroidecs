using CodeBase.Core.Data.Abstract;
using CodeBase.Core.Gameplay.Components.Moves;

namespace CodeBase.Core.Data.Applies
{
    public class ApplyAcceleration : ApplyConfigValue<Acceleration>
    {
        public ApplyAcceleration(IObjectConfigs configs) : base(configs) { }

        protected override bool OnHasValue(ObjectConfig config) =>
            config.Acceleration.HasValue;

        protected override void OnApply(ref Acceleration component, ObjectConfig config) =>
            // ReSharper disable once PossibleInvalidOperationException
            component.Modifier = config.Acceleration.Value;
    }
}
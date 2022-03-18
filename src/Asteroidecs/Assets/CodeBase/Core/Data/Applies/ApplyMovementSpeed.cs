using CodeBase.Core.Data.Abstract;
using CodeBase.Core.Gameplay.Components.Moves;

namespace CodeBase.Core.Data.Applies
{
    public class ApplyMovementSpeed : ApplyConfigValue<MovementSpeed>
    {
        public ApplyMovementSpeed(IConfigService configs) : base(configs) { }

        protected override bool OnHasValue(ObjectConfig config) =>
            config.MovementSpeed.HasValue;

        protected override void OnApply(ref MovementSpeed component, ObjectConfig config) =>
            // ReSharper disable once PossibleInvalidOperationException
            component.Value = config.MovementSpeed.Value;
    }
}
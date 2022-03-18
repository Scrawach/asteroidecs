using CodeBase.Core.Common;
using Leopotam.EcsLite;

namespace CodeBase.Core.Data.Abstract
{
    public interface IApplyConfigValue
    {
        bool TryApply(int entity, EcsWorld world, ObjectId objectId);
    }
}
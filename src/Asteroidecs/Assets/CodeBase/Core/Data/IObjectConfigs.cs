using CodeBase.Core.Common;

namespace CodeBase.Core.Data
{
    public interface IObjectConfigs
    {
        bool HasConfig(ObjectId id);
        ObjectConfig Get(ObjectId id);
    }
}
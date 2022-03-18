using CodeBase.Core.Common;

namespace CodeBase.Core.Data
{
    public interface IConfigService
    {
        bool HasConfig(ObjectId id);
        ObjectConfig Get(ObjectId id);
    }
}
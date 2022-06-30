using CodeBase.Core.Common;

namespace CodeBase.Core.Data
{
    public interface IObjectConfigs
    {
        bool Has(ObjectId id);
        ObjectConfig Get(ObjectId id);
    }
}
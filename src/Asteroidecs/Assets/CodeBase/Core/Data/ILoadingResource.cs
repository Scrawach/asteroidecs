using System.Threading.Tasks;

namespace CodeBase.Core.Data
{
    public interface ILoadingResource
    {
        Task Load();
    }
}
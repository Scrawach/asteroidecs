using System.Linq;
using System.Threading.Tasks;

namespace CodeBase.Core.Data
{
    public class LoadingResources : ILoadingResource
    {
        private readonly ILoadingResource[] _resources;

        public LoadingResources(params ILoadingResource[] resources) =>
            _resources = resources;
        
        public async Task Load()
        {
            var tasks = _resources.Select(resource => resource.Load());
            await Task.WhenAll(tasks.ToArray());
        }
    }
}
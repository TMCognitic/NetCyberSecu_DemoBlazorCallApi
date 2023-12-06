using DemoBlazor.Models.Entities;

namespace DemoBlazor.Models.Respositoris
{
    public interface IDataRepository
    {
        Task<IEnumerable<Data>?> Get();
    }
}

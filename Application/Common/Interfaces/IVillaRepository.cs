
using Domain.Models;

namespace Application.Common.Interfaces
{
    public interface IVillaRepository : IRepository<Villa>
    {
        public Task SaveImage(Villa villa);
        public Task DeleteImage(Villa villa);
    }
}

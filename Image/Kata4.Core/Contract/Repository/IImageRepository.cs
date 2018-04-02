using Kata4.Core.Model;

namespace Kata4.Core.Contract.Repository
{
    public interface IImageRepository : IRepository<Image, int>
    {
        Image Get(string name);
    }
}

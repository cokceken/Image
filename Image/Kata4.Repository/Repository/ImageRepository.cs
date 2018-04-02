using System.Linq;
using Kata4.Core.Contract.Repository;
using Kata4.Core.Model;

namespace Kata4.Repository.Repository
{
    public class ImageRepository : Repository<Image, int>, IImageRepository
    {
        public Image Get(string name)
        {
            return Session.Query<Image>().FirstOrDefault(x => x.Name == name);
        }
    }
}
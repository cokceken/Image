using System.Collections.Generic;
using Kata4.Core.Model;

namespace Kata4.Core.Contract.Service
{
    public interface IImageService
    {
        Image GetImage(int id);

        Image GetImage(string name);

        IEnumerable<Image> GetAllImages();
        void Save(Image image);
    }
}
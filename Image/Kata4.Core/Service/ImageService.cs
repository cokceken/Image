using System.Collections.Generic;
using System.Linq;
using Kata4.Core.Contract.Repository;
using Kata4.Core.Contract.Service;
using Kata4.Core.Model;
using Kata4.Core.Model.Attribute;
using Kata4.Core.Model.Exception;

namespace Kata4.Core.Service
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [UnitOfWork]
        public Image GetImage(int id)
        {
            var image = _imageRepository.Get(id);
            if (image == null)
            {
                throw new ImageNotFoundException($"Image not found found with id:{id}");
            }

            return image;
        }

        [UnitOfWork]
        public Image GetImage(string name)
        {
            var image = _imageRepository.Get(name);
            if (image == null)
            {
                throw new ImageNotFoundException($"Image not found found with name:{name}");
            }

            return image;
        }

        [UnitOfWork]
        public IEnumerable<Image> GetAllImages()
        {
            var images = _imageRepository.GetAll();
            if (images == null || !images.Any())
            {
                throw new ImageNotFoundException($"No image found");
            }

            return images.ToList();
        }

        [UnitOfWork]
        public void Save(Image image)
        {
            _imageRepository.Add(image);
        }
    }
}
using System;
using System.Drawing;
using System.IO;
using System.Web.Mvc;
using Kata4.Core.Contract.Service;
using Kata4.Web.Models;

namespace Kata4.Web.Controllers
{
    public class ImagePageController : Controller
    {
        private readonly IImageService _imageService;

        public ImagePageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public ActionResult Index()
        {
            var images = _imageService.GetAllImages();

            return View(new ImageListModel()
            {
                Images = images
            });
        }

        public ActionResult SaveImage()
        {
            var file = Image.FromFile(@"C:/Users/s.cokceken/Desktop/cokceken/Katas/AdaptiveAPI/Kata4.Web/testimg.jpg");
            byte[] data;
            using (var ms = new MemoryStream())
            {
                file.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                data = ms.ToArray();
            }

            var image = new Core.Model.Image()
            {
                Data = data,
                Name = "testimg"
            };

            _imageService.Save(image);

            return View("Index");
        }

        public ActionResult Show(int id)
        {
            var image = _imageService.GetImage(id);

            return File(image.Data, "image/jpg");
        }
    }
}
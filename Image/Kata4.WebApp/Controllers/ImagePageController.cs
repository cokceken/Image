using System;
using System.Drawing;
using System.IO;
using System.Web.Mvc;
using Kata4.Core.Contract.Service;

namespace Kata4.WebApp.Controllers
{
    public class ImagePageController : Controller
    {
        private readonly IImageService _imageService;

        public ImagePageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // GET: ImagePage
        public ActionResult Index()
        {
            return View();
        }

        //Adaptive api
        private string GetLiveImage(int imageId, bool throwExc = false)
        {
            try
            {
                string img = "";

                //The lookup of images should go to a database
                if (imageId == 1)
                    img = "testimg.jpg";

                if (img == string.Empty)
                {
                    var imgNotFoundExc = new Exception($"The image with given id couldn't be found.");
                    if (throwExc) throw imgNotFoundExc;
                }

                return img;
            }
            catch (Exception)
            {
                if (throwExc) throw;

                return null;
            }
        }

        public ActionResult SaveImage()
        {
            var file = Image.FromFile(@"~/testimg.jpg");
            byte[] data;
            using (var ms = new MemoryStream())
            {
                file.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                data = ms.ToArray();
            }

            Core.Model.Image image = new Core.Model.Image()
            {
                Data = data,
                Name = "testimg"
            };

            _imageService.Save(image);
        }

        public ActionResult Show(int id)
        {
            var image = _imageService.GetImage(id);

            return File(image.Data, "image/jpg");
        }
    }
}
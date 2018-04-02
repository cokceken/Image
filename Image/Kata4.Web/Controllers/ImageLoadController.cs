using System;
using System.IO;
using System.Web.Mvc;
using Kata4.Core.Contract.Service;
using Kata4.Core.Model;
using Kata4.Core.Model.Attribute;
using Kata4.Web.Models;

namespace Kata4.Web.Controllers
{
    public class ImageLoadController : Controller
    {
        private readonly IImageService _imageService;

        public ImageLoadController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [UnitOfWork]
        [HttpPost]
        public ActionResult Upload(ImageLoadModel model)
        {
            if (!ModelState.IsValid) return View("Index", model);

            using (var memoryStream = new MemoryStream())
            {
                model.UploadedImage.InputStream.CopyTo(memoryStream);
                _imageService.Save(new Image()
                {
                    Name = model.Name,
                    Data = memoryStream.ToArray()
                });

                model.Result = true;
            }

            return View("Index", model);
        }
    }
}
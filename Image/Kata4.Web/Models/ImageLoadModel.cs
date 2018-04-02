using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Kata4.Web.Models
{
    public class ImageLoadModel
    {
        [Required]
        public HttpPostedFileBase UploadedImage { get; set; }
        [Required]
        public string Name { get; set; }
        public bool? Result { get; set; }
    }
}
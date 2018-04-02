using System.Runtime.Serialization;
using Kata4.Core.Contract.Exception;

namespace Kata4.Core.Model.Exception
{
    public class ImageNotFoundException : System.Exception, IUserFriendlyException
    {
        public ImageNotFoundException()
        {
        }

        public ImageNotFoundException(string message) : base(message)
        {
        }

        public ImageNotFoundException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected ImageNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

namespace Kata4.Core.Model
{
    public class Image : BaseModel<int>
    {
        public virtual byte[] Data { get; set; }
        public virtual string Name { get; set; }
    }
}
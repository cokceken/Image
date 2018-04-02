namespace Kata4.Core.Model
{
    public abstract class BaseModel<T>
    {
        public virtual T Id { get; set; }
    }
}

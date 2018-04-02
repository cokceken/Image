using FluentNHibernate.Mapping;
using Kata4.Core.Model;

namespace Kata4.Repository.Map
{
    public class ImageMap : ClassMap<Image>
    {
        public ImageMap()
        {
            Id(x => x.Id);

            Map(x => x.Data).Length(int.MaxValue);
            Map(x => x.Name);

            Table("Image");
        }
    }
}

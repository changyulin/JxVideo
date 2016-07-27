using Jx.Core.Domain.Catalog;

namespace Jx.Data.Mapping.Catalog
{
    public partial class RelatedProductMap : NopEntityTypeConfiguration<RelatedProduct>
    {
        public RelatedProductMap()
        {
            this.ToTable("RelatedProduct");
            this.HasKey(c => c.Id);
        }
    }
}
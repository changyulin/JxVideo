using Jx.Core.Domain.Catalog;

namespace Jx.Data.Mapping.Catalog
{
    public partial class SpecificationAttributeMap : NopEntityTypeConfiguration<SpecificationAttribute>
    {
        public SpecificationAttributeMap()
        {
            this.ToTable("SpecificationAttribute");
            this.HasKey(sa => sa.Id);
            this.Property(sa => sa.Name).IsRequired();
        }
    }
}
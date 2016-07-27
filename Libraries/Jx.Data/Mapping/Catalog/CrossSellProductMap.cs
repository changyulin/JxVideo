using Jx.Core.Domain.Catalog;

namespace Jx.Data.Mapping.Catalog
{
    public partial class CrossSellProductMap : NopEntityTypeConfiguration<CrossSellProduct>
    {
        public CrossSellProductMap()
        {
            this.ToTable("CrossSellProduct");
            this.HasKey(c => c.Id);
        }
    }
}
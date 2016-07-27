using Jx.Core.Domain.Shipping;

namespace Jx.Data.Mapping.Shipping
{
    public class DeliveryDateMap : NopEntityTypeConfiguration<DeliveryDate>
    {
        public DeliveryDateMap()
        {
            this.ToTable("DeliveryDate");
            this.HasKey(dd => dd.Id);
            this.Property(dd => dd.Name).IsRequired().HasMaxLength(400);
        }
    }
}

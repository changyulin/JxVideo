using Jx.Core.Domain.Orders;

namespace Jx.Data.Mapping.Orders
{
    public partial class ReturnRequestActionMap : NopEntityTypeConfiguration<ReturnRequestAction>
    {
        public ReturnRequestActionMap()
        {
            this.ToTable("ReturnRequestAction");
            this.HasKey(rra => rra.Id);
            this.Property(rra => rra.Name).IsRequired().HasMaxLength(400);
        }
    }
}
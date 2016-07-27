using Jx.Core.Domain.Orders;

namespace Jx.Data.Mapping.Orders
{
    public partial class ReturnRequestReasonMap : NopEntityTypeConfiguration<ReturnRequestReason>
    {
        public ReturnRequestReasonMap()
        {
            this.ToTable("ReturnRequestReason");
            this.HasKey(rrr => rrr.Id);
            this.Property(rrr => rrr.Name).IsRequired().HasMaxLength(400);
        }
    }
}
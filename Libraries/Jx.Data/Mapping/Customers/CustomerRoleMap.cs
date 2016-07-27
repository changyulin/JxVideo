using Jx.Core.Domain.Customers;

namespace Jx.Data.Mapping.Customers
{
    public partial class CustomerRoleMap : NopEntityTypeConfiguration<CustomerRole>
    {
        public CustomerRoleMap()
        {
            this.ToTable("CustomerRole");
            this.HasKey(cr => cr.Id);
            this.Property(cr => cr.Name).IsRequired().HasMaxLength(255);
            this.Property(cr => cr.SystemName).HasMaxLength(255);
        }
    }
}
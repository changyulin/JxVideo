using Jx.Core.Domain.Discounts;

namespace Jx.Data.Mapping.Discounts
{
    public partial class DiscountRequirementMap : NopEntityTypeConfiguration<DiscountRequirement>
    {
        public DiscountRequirementMap()
        {
            this.ToTable("DiscountRequirement");
            this.HasKey(dr => dr.Id);
        }
    }
}
using Jx.Core.Domain.Vendors;

namespace Jx.Data.Mapping.Vendors
{
    public partial class VendorNoteMap : NopEntityTypeConfiguration<VendorNote>
    {
        public VendorNoteMap()
        {
            this.ToTable("VendorNote");
            this.HasKey(vn => vn.Id);
            this.Property(vn => vn.Note).IsRequired();

            this.HasRequired(vn => vn.Vendor)
                .WithMany(v => v.VendorNotes)
                .HasForeignKey(vn => vn.VendorId);
        }
    }
}
using Jx.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jx.Data.Mapping.Customers
{
    public class JxCodeMap : NopEntityTypeConfiguration<JxCode>
    {
        public JxCodeMap()
        {
            this.ToTable("JxCode");
            this.Ignore(jx => jx.Id);
            this.HasKey(jx => jx.Code);
            this.Property(jx => jx.College).HasMaxLength(20);
            this.Property(jx => jx.Major).HasMaxLength(20);
            this.Property(jx => jx.Grade).HasMaxLength(20);
            this.Property(jx => jx.StudNo).HasMaxLength(20);
            this.HasMany(jc => jc.Students).WithOptional().HasForeignKey(s => s.JxCode);
        }
    }
}

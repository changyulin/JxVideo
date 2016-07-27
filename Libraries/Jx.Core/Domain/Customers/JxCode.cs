using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jx.Core.Domain.Customers
{
    public class JxCode : BaseEntity
    {
        private ICollection<Customer> students;

        public string Code { get; set; }

        public string College { get; set; }

        public string Major { get; set; }

        public string Grade { get; set; }

        public string StudNo { get; set; }

        public bool IsValid { get; set; }

        public virtual ICollection<Customer> Students
        {
            get { return students ?? (students = new List<Customer>()); }
            protected set { students = value; }
        }
    }
}

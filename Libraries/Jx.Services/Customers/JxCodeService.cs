using Jx.Core.Domain.Customers;
using Jx.Data;
using Jx.Services.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jx.Services.Customers
{
    public class JxCodeService : IJxCodeService
    {
        private readonly IRepository<JxCode> jxCodeRepository;
        private readonly IEventPublisher eventPublisher;

        public JxCodeService(IRepository<JxCode> jxCodeRepository,
            IEventPublisher eventPublisher)
        {
            this.jxCodeRepository = jxCodeRepository;
            this.eventPublisher = eventPublisher;
        }

        public JxCode GetJxCodeById(string code)
        {
            return jxCodeRepository.Table.Where(x => x.Code == code).FirstOrDefault();
        }

        public void InsertJxCode(JxCode jxCode)
        {
            if (jxCode == null)
                throw new ArgumentNullException("jxCode");
            jxCodeRepository.Insert(jxCode);
            this.eventPublisher.EntityInserted(jxCode);
        }

        public void UpdateJxCode(JxCode jxCode)
        {
            if (jxCode == null)
                throw new ArgumentNullException("jxCode");
            jxCodeRepository.Update(jxCode);
            this.eventPublisher.EntityUpdated(jxCode);
        }

        public void DeleteJxCode(JxCode jxCode)
        {
            if (jxCode == null)
                throw new ArgumentNullException("jxCode");
            jxCodeRepository.Delete(jxCode);
            this.eventPublisher.EntityDeleted(jxCode);
        }

        public bool IsCodeValid(string code)
        {
            JxCode jxCode = this.GetJxCodeById(code);
            if (jxCode != null
                && jxCode.IsValid == true)
                return true;
            else
                return false;
        }

        public bool IsStudNoValid(string code, string studNo)
        {
            JxCode jxCode = this.GetJxCodeById(code);
            if (jxCode != null && jxCode.StudNo == studNo)
               return true; 
            else
                return false;
        }
    }
}

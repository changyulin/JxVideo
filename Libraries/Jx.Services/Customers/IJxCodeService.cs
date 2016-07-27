using Jx.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jx.Services.Customers
{
    public interface IJxCodeService
    {
        /// <summary>
        /// Get a jxCode
        /// </summary>
        /// <param name="code">JxCode identifier</param>
        /// <returns></returns>
        JxCode GetJxCodeById(String code);

        /// <summary>
        /// Insert a jxCode
        /// </summary>
        /// <param name="jxCode">JxCode</param>
        void InsertJxCode(JxCode jxCode);

        /// <summary>
        /// Updates the jxCode
        /// </summary>
        /// <param name="jxCode">JxCode</param>
        void UpdateJxCode(JxCode jxCode);

        /// <summary>
        /// Delete a jxCode
        /// </summary>
        /// <param name="jxCode">JxCode</param>
        void DeleteJxCode(JxCode jxCode);

        /// <summary>
        /// Whether code valid
        /// </summary>
        /// <param name="code">JxCode identifier</param>
        /// <returns></returns>
        bool IsCodeValid(String code);

        /// <summary>
        /// Whether studNo valid
        /// </summary>
        /// <param name="code">JxCode identifier</param>
        /// <param name="studNo">student number</param>
        /// <returns></returns>
        bool IsStudNoValid(string code, string studNo);
    }
}

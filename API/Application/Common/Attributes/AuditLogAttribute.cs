using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Attributes
{
    /// <summary>
    /// Indicate if a specific IRequest has to be audited
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class AuditLogAttribute : Attribute
    {
    }
}

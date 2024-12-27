using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLI.Domain.Commons
{
    public class EntityAudit<T> : EntityBase<T>
    {
        public DateTime CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}

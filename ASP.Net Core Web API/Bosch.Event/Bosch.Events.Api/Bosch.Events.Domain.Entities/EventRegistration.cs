using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.Events.Domain.Entities
{
    public class EventRegistration
    {
        public int EventId { get; set; }
        public int EmployeeId { get; set; }
        public virtual Event Event { get; set; }
        public virtual Employee Employee { get; set; }
    }
}

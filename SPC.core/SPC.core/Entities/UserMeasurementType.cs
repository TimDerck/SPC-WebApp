using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.core.Entities
{
    public class UserMeasurementType
    {
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public Guid MeasurementTypeId { get; set; }
        public MeasurementType MeasurementType { get; set; }
    }
}

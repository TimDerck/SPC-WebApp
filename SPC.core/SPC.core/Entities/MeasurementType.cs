using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.core.Entities
{
    public class MeasurementType : BaseEntity
    {
        public string TypeName { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public bool HasCalculatedResult { get; set; } = false;
        public ICollection<UserMeasurementType> UserMeasurementTypes { get; set; }
    }
}

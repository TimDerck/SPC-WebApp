using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.core.Entities
{
    public class RawMeasurement : BaseEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string SampleId { get; set; }
        public double RawValue { get; set; }
        public string Unit { get; set; }
        public Guid MeasurementTypeId { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public string RefSampleId { get; set; }
    }
}

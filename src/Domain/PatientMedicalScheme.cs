using MedPark.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Domain
{
    public class PatientMedicalScheme : BaseIdentifiable
    {
        public PatientMedicalScheme(Guid id) : base(id)
        {

        }

        public Guid PatientId { get; private set; }
        public Guid SchemeId { get; private set; }

        public void UpdatedModifiedDate()
            => UpdatedModified();

        public void SetCustomer(Guid schemeId)
        {
            PatientId = schemeId;
        }

        public void SetScheme(Guid schemeId)
        {
            SchemeId = schemeId;
        }
    }
}

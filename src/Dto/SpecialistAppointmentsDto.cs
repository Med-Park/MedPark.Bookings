using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Dto
{
    public class SpecialistAppointmentsDto
    {
        public List<SpecialistAppointmentDto> BookingDetails { get; set; }

        public SpecialistAppointmentsDto()
        {
            BookingDetails = new List<SpecialistAppointmentDto>();
        }
    }
}

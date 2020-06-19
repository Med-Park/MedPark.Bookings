using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Dto
{
    public class CustomerAppointmentsDto
    {
        public List<AppointmentDto> BookingDetails { get; set; }

        public CustomerAppointmentsDto()
        {
            BookingDetails = new List<AppointmentDto>();
        }
    }
}

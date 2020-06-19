using MedPark.Bookings.Dto;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Queries
{
    public class CustomerAppointmentQuery : IQuery<CustomerAppointmentsDto>
    {
        public Guid CustomerId { get; set; }
    }
}

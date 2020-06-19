using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.Bookings.Dto;
using MedPark.Bookings.Queries;
using MedPark.Common;
using MedPark.Common.Cache;
using MedPark.Common.Dispatchers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPark.Bookings.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public AppointmentsController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("getspecialistappointments/{specialistid}")]
        [Cached(Constants.HalfHour_In_Seconds)]
        public async Task<IActionResult> GetSpecialistAppointments([FromRoute] SpecialistAppointmentQuery query)
        {
            try
            {
                SpecialistAppointmentsDto bookings = await _dispatcher.QueryAsync(query);

                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getpatientappointments/{customerid}")]
        [Cached(Constants.Day_In_Seconds)]
        public async Task<IActionResult> GetCustomerAppointments([FromRoute] CustomerAppointmentQuery query)
        {
            try
            {
                CustomerAppointmentsDto patientBookings = await _dispatcher.QueryAsync(query);

                return Ok(patientBookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{appointmentid}/details")]
        [Cached(Constants.Day_In_Seconds)]
        public async Task<IActionResult> GetCustomerAppointments([FromRoute] AppointmentDetailQuery query)
        {
            try
            {
                AppointmentDetailDto appointment = await _dispatcher.QueryAsync<AppointmentDetailDto>(query);

                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
using AutoMapper;
using MedPark.Bookings.Domain;
using MedPark.Bookings.Dto;
using MedPark.Bookings.Queries;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Handlers.Bookings
{
    public class CustomerAppointmentsQueryHandler : IQueryHandler<CustomerAppointmentQuery, CustomerAppointmentsDto>
    {
        private IMedParkRepository<Appointment> _bookingsRepo;
        private IMedParkRepository<Patient> _patientRepo;
        private IMedParkRepository<Specialist> _specialistRepo;
        private IMapper _mapper;

        public CustomerAppointmentsQueryHandler(IMedParkRepository<Appointment> bookingsRepo, IMedParkRepository<Patient> patientRepo, IMapper mapper, IMedParkRepository<Specialist> specialistRepo)
        {
            _bookingsRepo = bookingsRepo;
            _patientRepo = patientRepo;
            _mapper = mapper;
            _specialistRepo = specialistRepo;
        }

        public async Task<CustomerAppointmentsDto> HandleAsync(CustomerAppointmentQuery query)
        {
            Patient patient = await _patientRepo.GetAsync(query.CustomerId);

            IEnumerable<Appointment> bookings = await _bookingsRepo.FindAsync(x => x.PatientId == query.CustomerId);

            if (patient is null)
                throw new MedParkException("bookings_patient_does_not_exist", $"Patient with Id {query.CustomerId} does not exist.");

            CustomerAppointmentsDto result = new CustomerAppointmentsDto();

            bookings.ToList().ForEach(b =>
            {
                Specialist bookedSpecilaist = _specialistRepo.GetAsync(b.SpecialistId).Result;

                result.BookingDetails.Add(new AppointmentDto
                {
                    Created = b.Created,
                    Modified = b.Modified,
                    Id = b.Id,
                    PatientId = patient.Id,
                    ScheduledDate = b.ScheduledDate,
                    SpecialistEmail = bookedSpecilaist.Email,
                    SpecialistId = bookedSpecilaist.Id,
                    SpecialistInitials = (bookedSpecilaist.FirstName).GetInitials(),
                    SpecialistSurname = bookedSpecilaist.Surname,
                    SpecialistTel = bookedSpecilaist.Cellphone,
                    Title = bookedSpecilaist.Title
                });
            });

            return result;
        }
    }
}

using MedPark.Bookings.Domain;
using MedPark.Bookings.Messages.Events;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Handlers.Customers
{
    public class CustomerMedicalSchemeAddedHandler : IEventHandler<CustomerMedicalSchemeAdded>
    {
        private IMedParkRepository<PatientMedicalScheme> _patientMedicalScheme { get; }

        public CustomerMedicalSchemeAddedHandler(IMedParkRepository<PatientMedicalScheme> patientMedicalScheme)
        {
            _patientMedicalScheme = patientMedicalScheme;
        }

        public async Task HandleAsync(CustomerMedicalSchemeAdded @event, ICorrelationContext context)
        {
            PatientMedicalScheme newpatientScheme = new PatientMedicalScheme(Guid.NewGuid());

            newpatientScheme.SetCustomer(@event.CustomerId);
            newpatientScheme.SetScheme(@event.MedicalSchemeId);

            await _patientMedicalScheme.AddAsync(newpatientScheme);
        }
    }
}

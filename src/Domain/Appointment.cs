using MedPark.Common;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings.Domain
{
    public class Appointment : BaseIdentifiable
    {
        public Appointment(Guid id) : base(id)
        {

        }

        public Guid PatientId { get; private set; }
        public Guid SpecialistId { get; private set; }
        public Guid? PatientMedicalSchemeId { get; private set; }

        public DateTime ScheduledDate { get; private set; }
        public bool IsPostponement { get; private set; }
        public string Comment { get; private set; }



        public void SetPatientDetails(string name, string surname, string mobile, string email, Guid patientId)
        {
            PatientId = patientId;
        }

        public void SetSpecialistDetails(Guid specialistId)
        {
            SpecialistId = specialistId;
        }

        public void SetAppointmentDetails(DateTime date, bool isPostponetment)
        {
            ScheduledDate = date;
            IsPostponement = IsPostponement;
        }

        public void SetComment(string comment)
        {
            Comment = comment;
        }

        public void SetMedicalScheme(Guid medSchemeId)
        {
            PatientMedicalSchemeId = medSchemeId;
        }

        public override void Use()
        {
            base.Use();

            if (string.IsNullOrEmpty(SpecialistId.ToString()) || string.IsNullOrEmpty(PatientId.ToString()))
                throw new MedParkException("add_appointment_specialist_deatils_cannot_be_null", "Specialist details cannot be null.");
        }
    }
}

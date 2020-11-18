using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Service
{
    /// <summary>Class <c>FeedbackService</c> handles feedback business logic.
    /// </summary>
    public class PrescriptionService
    {
        /// <value>Property <c>PrescriptionRepository</c> represents the repository used for data access.</value>
        private PrescriptionRepository PrescriptionRepository { get; set; }

        /// <summary>This constructor injects the PrescriptionService with matching PrescriptionRepository.</summary>
        /// <param name="context"><c>context</c> is type of <c>DbContext</c>, and it's used for accessing MYSQL database.</param>
        public PrescriptionService(MyDbContext context)
        {
            PrescriptionRepository = new PrescriptionRepository(context);
        }

        /// <summary> This method is calling <c>PrescriptionRepository</c> to get list of all<c>Prescription</c>. </summary>
        /// <returns> List of all prescriptions. </returns>
        public List<Prescription> GetAll()
        {
            return PrescriptionRepository.GetAll();
        }

        /// <summary> This method is calling <c>PrescriptionRepository</c> to get list of all <c>Prescription</c> of logged patient. </summary>
        /// /// <param name="idPatient"><c>idPatient</c> is <c>id</c> of a <c>PatientUser</c> that is logged.
        /// </param>
        /// <returns> List of all patient prescriptions. </returns>
        public List<Prescription> GetPrescriptionsForPatient(int idPatient)
        {
            return PrescriptionRepository.GetPrescriptionsForPatient(idPatient);
        }

    }
}

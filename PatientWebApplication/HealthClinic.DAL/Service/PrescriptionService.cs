using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthClinic.CL.Service
{
    /// <summary>Class <c>FeedbackService</c> handles feedback business logic.
    /// </summary>
    public class PrescriptionService
    {
        /// <value>Property <c>PrescriptionRepository</c> represents the repository used for data access.</value>
        private IPrescriptionRepository PrescriptionRepository { get; set; }

        /// <summary>This constructor injects the PrescriptionService with matching PrescriptionRepository.</summary>
        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            PrescriptionRepository = prescriptionRepository;
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

        public List<Prescription> SimpleSearchPrescriptions(PrescriptionSearchDto prescriptionSearchDto)
        {
            List<Prescription> prescriptions = GetPrescriptionsForPatient(1);

            prescriptions = searchForComments(prescriptions, prescriptionSearchDto);

            prescriptions = searchForUsed(prescriptions, prescriptionSearchDto);

            prescriptions = searchForMedicines(prescriptions, prescriptionSearchDto);
       
            return prescriptions;

        }

        private List<Prescription> searchForUsed(List<Prescription> prescriptions, PrescriptionSearchDto prescriptionSearchDto)
        {
            if (!prescriptionSearchDto.IsUsed.Equals(""))
            {
                prescriptions = prescriptions.FindAll(prescription => prescription.isUsed.ToString().Equals(prescriptionSearchDto.IsUsed));
            }

            return prescriptions;
        }

        private List<Prescription> searchForComments(List<Prescription> prescriptions, PrescriptionSearchDto prescriptionSearchDto)
        {
            if (!prescriptionSearchDto.Comment.Equals(""))
            {
                prescriptions = prescriptions.FindAll(prescription => prescription.comment.Equals(prescriptionSearchDto.Comment));
            }

            return prescriptions;
        }

        private List<Prescription> searchForMedicines(List<Prescription> prescriptions, PrescriptionSearchDto prescriptionSearchDto)
        {
            if (!prescriptionSearchDto.Medicines.Equals(""))
            {
                List<Prescription> prescriptionsToReturn = new List<Prescription>();

                prescriptions = prescriptions.Where(prescription => prescription.Medicines.Any(medicine => medicine.name.Equals(prescriptionSearchDto.Medicines))).ToList();
          
            }

            return prescriptions;
        }
    }
}

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

        /// <summary> This method is calling searchForComments, searchForUsed, searchForMedicines to get list of filtered <c>Prescription</c> of logged patient. </summary>
        /// /// <param name="prescriptionSearchDto"><c>prescriptionSearchDto</c> is Data Transfer Object of a <c>Prescription</c> that is beomg used to filter precriptions.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        public List<Prescription> SimpleSearchPrescriptions(PrescriptionSearchDto prescriptionSearchDto)
        {
            List<Prescription> prescriptions = GetPrescriptionsForPatient(1);

            prescriptions = searchForComments(prescriptions, prescriptionSearchDto);

            prescriptions = searchForUsed(prescriptions, prescriptionSearchDto);

            prescriptions = searchForMedicines(prescriptions, prescriptionSearchDto);

            prescriptions = searchForDoctor(prescriptions, prescriptionSearchDto);

            return prescriptions;

        }

        /// <summary> This method is calling searchForFirstParameter, searchForOtherParameters to get list of filtered <c>Prescription</c> of logged patient. </summary>
        /// /// <param name="dto"><c>PrescriptionAdvancedSearchDto</c> is Data Transfer Object of a <c>Prescription</c> that is beomg used to filter precriptions.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        public List<Prescription> AdvancedSearchPrescriptions(PrescriptionAdvancedSearchDto dto)
        {
            List<Prescription> prescriptions = GetPrescriptionsForPatient(1);

            List<Prescription> firstPrescriptions = searchForFirstParameter(prescriptions, dto);

            List<Prescription> finalPrescriptions = searchForOtherParameters(prescriptions, dto, firstPrescriptions);

            return finalPrescriptions;
        }

        private List<Prescription> searchForOtherParameters(List<Prescription> prescriptions, PrescriptionAdvancedSearchDto dto, List<Prescription> firstPrescriptions)
        {
            List<Prescription> othersPrescriptions = new List<Prescription>();

            List<Prescription> finalPrescriptions = firstPrescriptions;

            for (int i = 0; i < dto.RestRoles.Length; i++)
            {
                othersPrescriptions = searchForOtherRoles(dto.RestRoles[i], dto.Rest[i], prescriptions, othersPrescriptions);

                
                if (i == 0)
                {
                    finalPrescriptions = searchForLogicOperators(dto.LogicOperators[i], othersPrescriptions, firstPrescriptions);            
                } else
                {
                    finalPrescriptions = searchForLogicOperators(dto.LogicOperators[i], othersPrescriptions, finalPrescriptions);   
                }

                
            }

            return finalPrescriptions;
        }

        private List<Prescription> searchForLogicOperators(string logicOperator, List<Prescription> othersPrescriptions, List<Prescription> finalPrescriptions)
        {
            if (logicOperator.Equals("or"))
            {
                finalPrescriptions = othersPrescriptions.Union(finalPrescriptions).ToList();
            }
            else
            {
                finalPrescriptions = othersPrescriptions.Intersect(finalPrescriptions).ToList();
            }
            return finalPrescriptions;
        }

        private List<Prescription> searchForOtherRoles(string restRole, string rest, List<Prescription> prescriptions, List<Prescription> othersPrescriptions)
        {
            if (restRole.Equals("medicines"))
            {
                othersPrescriptions = searchForMedicinesAdvanced(prescriptions, rest);
            }
            else if (restRole.Equals("comment"))
            {
                othersPrescriptions = searchForCommentsAdvanced(prescriptions, rest);
            }
            else if (restRole.Equals("isUsed"))
            {
                othersPrescriptions = searchForUsedAdvanced(prescriptions, rest);
            }
            else
            {
                othersPrescriptions = searchForDoctorAdvanced(prescriptions, rest);
            }
            return othersPrescriptions;
        }

        private List<Prescription> searchForFirstParameter(List<Prescription> prescriptions, PrescriptionAdvancedSearchDto dto)
        {
            List<Prescription> firstPrescriptions = new List<Prescription>();
            if (dto.FirstRole.Equals("medicines"))
            {
                firstPrescriptions = searchForMedicinesAdvanced(prescriptions, dto.First);
            }
            else if (dto.FirstRole.Equals("comment"))
            {
                firstPrescriptions = searchForCommentsAdvanced(prescriptions, dto.First);
            }
            else if (dto.FirstRole.Equals("isUsed"))
            {
                firstPrescriptions = searchForUsedAdvanced(prescriptions, dto.First);
            }
            else
            {
                firstPrescriptions = searchForDoctorAdvanced(prescriptions, dto.First);
            }

            return firstPrescriptions;
        }

        private List<Prescription> searchForDoctorAdvanced(List<Prescription> prescriptions, String searchField)
        {
            if (!searchField.Equals(""))
            {
                prescriptions = prescriptions.FindAll(prescription => prescription.Doctor.firstName.Equals(searchField) || prescription.Doctor.secondName.Equals(searchField) || prescription.Doctor.DoctorFullName().Equals(searchField));
            }

            return prescriptions;
        }

        private List<Prescription> searchForUsedAdvanced(List<Prescription> prescriptions, String searchField)
        {
            if (!searchField.Equals(""))
            {
                prescriptions = prescriptions.FindAll(prescription => prescription.isUsed.ToString().Equals(searchField));
            }

            return prescriptions;
        }

        private List<Prescription> searchForCommentsAdvanced(List<Prescription> prescriptions, String searchField)
        {
            if (!searchField.Equals(""))
            {
                prescriptions = prescriptions.FindAll(prescription => prescription.comment.Equals(searchField));
            }

            return prescriptions;
        }

        private List<Prescription> searchForMedicinesAdvanced(List<Prescription> prescriptions, String searchField)
        {
            if (!searchField.Equals(""))
            {
                prescriptions = prescriptions.Where(prescription => prescription.Medicines.Any(medicine => medicine.name.Equals(searchField))).ToList();
            }

            return prescriptions;
        }

        /// <summary> This method is getting list of filtered <c>Prescription</c> of logged patient by parameter <c>Doctor</c>. </summary>
        /// /// <param name="prescriptions"><c>prescriptions</c> is List of presciptions that matches search fields.
        /// </param>
        /// /// <param name="prescriptionSearchDto"><c>prescriptionSearchDto</c> is Data Transfer Object of a <c>Prescription</c> that is beomg used to filter precriptions.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        private List<Prescription> searchForDoctor(List<Prescription> prescriptions, PrescriptionSearchDto prescriptionSearchDto)
        {
            if (!prescriptionSearchDto.Doctor.Equals(""))
            {
                prescriptions = prescriptions.FindAll(prescription => prescription.Doctor.firstName.Equals(prescriptionSearchDto.Doctor) || prescription.Doctor.secondName.Equals(prescriptionSearchDto.Doctor) || prescription.Doctor.DoctorFullName().Equals(prescriptionSearchDto.Doctor));
            }

            return prescriptions;
        }

        /// <summary> This method is getting list of filtered <c>Prescription</c> of logged patient by parameter <c>IsUsed</c>. </summary>
        /// /// <param name="prescriptions"><c>prescriptions</c> is List of presciptions that matches search fields.
        /// </param>
        /// /// <param name="prescriptionSearchDto"><c>prescriptionSearchDto</c> is Data Transfer Object of a <c>Prescription</c> that is beomg used to filter precriptions.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        private List<Prescription> searchForUsed(List<Prescription> prescriptions, PrescriptionSearchDto prescriptionSearchDto)
        {
            if (!prescriptionSearchDto.IsUsed.Equals(""))
            {
                prescriptions = prescriptions.FindAll(prescription => prescription.isUsed.ToString().Equals(prescriptionSearchDto.IsUsed));
            }

            return prescriptions;
        }

        /// <summary> This method is getting list of filtered <c>Prescription</c> of logged patient by parameter <c>Comment</c>. </summary>
        /// /// <param name="prescriptions"><c>prescriptions</c> is List of presciptions that matches search fields.
        /// </param>
        /// /// <param name="prescriptionSearchDto"><c>prescriptionSearchDto</c> is Data Transfer Object of a <c>Prescription</c> that is beomg used to filter precriptions.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        private List<Prescription> searchForComments(List<Prescription> prescriptions, PrescriptionSearchDto prescriptionSearchDto)
        {
            if (!prescriptionSearchDto.Comment.Equals(""))
            {
                prescriptions = prescriptions.FindAll(prescription => prescription.comment.Equals(prescriptionSearchDto.Comment));
            }

            return prescriptions;
        }

        /// <summary> This method is getting list of filtered <c>Prescription</c> of logged patient by parameter <c>Messages</c>. </summary>
        /// /// <param name="prescriptions"><c>prescriptions</c> is List of presciptions that matches search fields.
        /// </param>
        /// /// <param name="prescriptionSearchDto"><c>prescriptionSearchDto</c> is Data Transfer Object of a <c>Prescription</c> that is beomg used to filter precriptions.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        private List<Prescription> searchForMedicines(List<Prescription> prescriptions, PrescriptionSearchDto prescriptionSearchDto)
        {
            if (!prescriptionSearchDto.Medicines.Equals(""))
            {

                prescriptions = prescriptions.Where(prescription => prescription.Medicines.Any(medicine => medicine.name.Equals(prescriptionSearchDto.Medicines))).ToList();
          
            }

            return prescriptions;
        }
    }
}

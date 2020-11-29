using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Utility;
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
            return SearchForDoctor(SearchForMedicines(SearchForUsed(SearchForComments(GetPrescriptionsForPatient(1), prescriptionSearchDto), prescriptionSearchDto), prescriptionSearchDto), prescriptionSearchDto);

        }

        /// <summary> This method is calling searchForFirstParameter, searchForOtherParameters to get list of filtered <c>Prescription</c> of logged patient. </summary>
        /// /// <param name="dto"><c>PrescriptionAdvancedSearchDto</c> is Data Transfer Object of a <c>Prescription</c> that is beomg used to filter precriptions.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        public List<Prescription> AdvancedSearchPrescriptions(PrescriptionAdvancedSearchDto dto)
        {
            return SearchForOtherParameters(GetPrescriptionsForPatient(1), dto, SearchForFirstParameter(GetPrescriptionsForPatient(1), dto));
        }

        /// <summary> This method is getting list of filtered <c>Prescription</c> that match list of parameters in <c>PrescriptionAdvnacedSearchDto</c></summary>
        /// <param name="prescriptions"> List of all <c>Prescription</c> of logged user.
        /// </param>
        /// <param name="dto"><c>PrescriptionAdvancedSearchDto</c> is Data Transfer Object of a <c>Prescription</c> that is beomg used to filter precriptions.
        /// </param>
        /// <param name="firstPrescriptions"> List of <c>Prescription</c> that contains prescriptions that matches first parameter.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        private List<Prescription> SearchForOtherParameters(List<Prescription> prescriptions, PrescriptionAdvancedSearchDto dto, List<Prescription> firstPrescriptions)
        {
           for (int i = 0; i < dto.RestRoles.Length; i++)
            {
                List<Prescription> othersPrescriptions = SearchForOtherParametersValues(dto.RestRoles[i], dto.Rest[i], prescriptions);

                firstPrescriptions = SearchForLogicOperators(dto.LogicOperators[i], othersPrescriptions, firstPrescriptions);           
            }

            return firstPrescriptions;
        }

        /// <summary> This method is either merging 2 lists of filtered <c>Prescription</c> on logical operator AND or OR depending on sent parameter</summary>
        /// /// <param name="logicOperator"><c>logicOperator</c> contains type of logical operator how we want to merge 2 lists of filtered <c>Prescription</c>.
        /// </param>
        /// /// /// <param name="othersPrescriptions"><c>othersPrescriptions</c> is first list of filtered <c>Prescription</c>.
        /// </param>
        /// /// <param name="finalPrescriptions"><c>finalPrescriptions</c> is second list of filtered <c>Prescription</c>.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        private List<Prescription> SearchForLogicOperators(string logicOperator, List<Prescription> othersPrescriptions, List<Prescription> finalPrescriptions)
        {
            return logicOperator.Equals("or") ? othersPrescriptions.Union(finalPrescriptions).ToList() : othersPrescriptions.Intersect(finalPrescriptions).ToList();
        }

        /// <summary> This method is calling function for getting list of filtered <c>Prescription</c> of logged patient by sent parameters </summary>
        /// /// <param name="otherParameter"><c>otherParameter</c> is string that contains type of parameter on which we want to filter prescriptions.
        /// </param>
        /// /// /// <param name="otherValue"><c>otherValue</c> is string that contains value of parameter which we use to filter prescriptions.
        /// </param>
        /// /// <param name="prescriptions"><c>prescriptions</c> is List of presciptions that matches search fields.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        private List<Prescription> SearchForOtherParametersValues(string otherParameter, string otherValue, List<Prescription> prescriptions)
        {
            return otherParameter.Equals("medicines") ? SearchForMedicinesAdvanced(prescriptions, otherValue) : 
                otherParameter.Equals("comment") ? SearchForCommentsAdvanced(prescriptions, otherValue) : 
                otherParameter.Equals("isUsed") ? SearchForUsedAdvanced(prescriptions, otherValue) : 
                SearchForDoctorAdvanced(prescriptions, otherValue);
        }

        /// <summary> This method is calling function for getting list of filtered <c>Prescription</c> of logged patient by sent parameter. </summary>
        /// /// <param name="prescriptions"><c>prescriptions</c> is List of presciptions that matches search fields.
        /// </param>
        /// /// <param name="dto"><c>PrescriptionAdvancedSearchDto</c> is Data Transfer Object of <c>Prescription</c> and is being used to filter precriptions depending on sent value.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        private List<Prescription> SearchForFirstParameter(List<Prescription> prescriptions, PrescriptionAdvancedSearchDto dto)
        {
            return dto.FirstRole.Equals("medicines") || UtilityMethods.CheckIfStringIsEmpty(dto.FirstRole) ? SearchForMedicinesAdvanced(prescriptions, dto.First) :
                dto.FirstRole.Equals("comment") ? SearchForCommentsAdvanced(prescriptions, dto.First) :
                dto.FirstRole.Equals("isUsed") ? SearchForUsedAdvanced(prescriptions, dto.First) : SearchForDoctorAdvanced(prescriptions, dto.First);
        }

        /// <summary> This method is getting list of filtered <c>Prescription</c> of logged patient by parameter <c>Doctor</c>. </summary>
        /// /// <param name="prescriptions"><c>prescriptions</c> is List of presciptions that matches search fields.
        /// </param>
        /// /// <param name="searchField"><c>searchField</c> is field that contains doctors name or surname and is being used to filter precriptions.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        private List<Prescription> SearchForDoctorAdvanced(List<Prescription> prescriptions, String searchField)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(searchField))
            {
                prescriptions = prescriptions.FindAll(prescription => prescription.Doctor.firstName.Contains(searchField) || prescription.Doctor.secondName.Contains(searchField) || prescription.Doctor.DoctorFullName().Contains(searchField));
            }

            return prescriptions;
        }

        /// <summary> This method is getting list of filtered <c>Prescription</c> of logged patient by parameter <c>IsUsed</c>. </summary>
        /// /// <param name="prescriptions"><c>prescriptions</c> is List of presciptions that matches search fields.
        /// </param>
        /// /// <param name="searchField"><c>searchField</c> is field that contains true or false for parameter is used and is being used to filter precriptions.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        private List<Prescription> SearchForUsedAdvanced(List<Prescription> prescriptions, String searchField)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(searchField))
            {
                prescriptions = prescriptions.FindAll(prescription => prescription.isUsed.ToString().Contains(searchField));
            }

            return prescriptions;
        }

        /// <summary> This method is getting list of filtered <c>Prescription</c> of logged patient by parameter <c>Comment</c>. </summary>
        /// /// <param name="prescriptions"><c>prescriptions</c> is List of presciptions that matches search fields.
        /// </param>
        /// /// <param name="searchField"><c>searchField</c> is field that contains comment and is being used to filter precriptions.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        private List<Prescription> SearchForCommentsAdvanced(List<Prescription> prescriptions, String searchField)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(searchField))
            {
                prescriptions = prescriptions.FindAll(prescription => prescription.comment.Contains(searchField));
            }

            return prescriptions;
        }

        /// <summary> This method is getting list of filtered <c>Prescription</c> of logged patient by parameter <c>Messages</c>. </summary>
        /// /// <param name="prescriptions"><c>prescriptions</c> is List of presciptions that matches search fields.
        /// </param>
        /// /// <param name="searchField"><c>searchField</c> is field that contains medicine name and is being used to filter precriptions.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        private List<Prescription> SearchForMedicinesAdvanced(List<Prescription> prescriptions, String searchField)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(searchField))
            {
                prescriptions = prescriptions.Where(prescription => prescription.Medicines.Any(medicine => medicine.name.Contains(searchField))).ToList();
            }

            return prescriptions;
        }

        /// <summary> This method is getting list of filtered <c>Prescription</c> of logged patient by parameter <c>Doctor</c>. </summary>
        /// /// <param name="prescriptions"><c>prescriptions</c> is List of presciptions that matches search fields.
        /// </param>
        /// /// <param name="prescriptionSearchDto"><c>prescriptionSearchDto</c> is Data Transfer Object of a <c>Prescription</c> that is being used to filter precriptions.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        private List<Prescription> SearchForDoctor(List<Prescription> prescriptions, PrescriptionSearchDto prescriptionSearchDto)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(prescriptionSearchDto.Doctor))
            {
                prescriptions = prescriptions.FindAll(prescription => prescription.Doctor.firstName.Contains(prescriptionSearchDto.Doctor) || prescription.Doctor.secondName.Contains(prescriptionSearchDto.Doctor) || prescription.Doctor.DoctorFullName().Contains(prescriptionSearchDto.Doctor));
            }

            return prescriptions;
        }

        /// <summary> This method is getting list of filtered <c>Prescription</c> of logged patient by parameter <c>IsUsed</c>. </summary>
        /// /// <param name="prescriptions"><c>prescriptions</c> is List of presciptions that matches search fields.
        /// </param>
        /// /// <param name="prescriptionSearchDto"><c>prescriptionSearchDto</c> is Data Transfer Object of a <c>Prescription</c> that is being used to filter precriptions.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        private List<Prescription> SearchForUsed(List<Prescription> prescriptions, PrescriptionSearchDto prescriptionSearchDto)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(prescriptionSearchDto.IsUsed))
            {
                prescriptions = prescriptions.FindAll(prescription => prescription.isUsed.ToString().Contains(prescriptionSearchDto.IsUsed));
            }

            return prescriptions;
        }

        /// <summary> This method is getting list of filtered <c>Prescription</c> of logged patient by parameter <c>Comment</c>. </summary>
        /// /// <param name="prescriptions"><c>prescriptions</c> is List of presciptions that matches search fields.
        /// </param>
        /// /// <param name="prescriptionSearchDto"><c>prescriptionSearchDto</c> is Data Transfer Object of a <c>Prescription</c> that is being used to filter precriptions.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        private List<Prescription> SearchForComments(List<Prescription> prescriptions, PrescriptionSearchDto prescriptionSearchDto)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(prescriptionSearchDto.Comment))
            {
                prescriptions = prescriptions.FindAll(prescription => prescription.comment.Contains(prescriptionSearchDto.Comment));
            }

            return prescriptions;
        }

        /// <summary> This method is getting list of filtered <c>Prescription</c> of logged patient by parameter <c>Messages</c>. </summary>
        /// /// <param name="prescriptions"><c>prescriptions</c> is List of presciptions that matches search fields.
        /// </param>
        /// /// <param name="prescriptionSearchDto"><c>prescriptionSearchDto</c> is Data Transfer Object of a <c>Prescription</c> that is being used to filter precriptions.
        /// </param>
        /// <returns> List of filtered patient prescriptions. </returns>
        private List<Prescription> SearchForMedicines(List<Prescription> prescriptions, PrescriptionSearchDto prescriptionSearchDto)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(prescriptionSearchDto.Medicines))
            {
                prescriptions = prescriptions.Where(prescription => prescription.Medicines.Any(medicine => medicine.name.Contains(prescriptionSearchDto.Medicines))).ToList();
            }

            return prescriptions;
        }
    }
}

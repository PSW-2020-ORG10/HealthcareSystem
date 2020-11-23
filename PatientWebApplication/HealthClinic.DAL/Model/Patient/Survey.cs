using HealthClinic.CL.Model.Doctor;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Model.Patient
{
    public class Survey : Entity
    {
        //for doctors
        public virtual DoctorUser doctor { get; set; }

        public int doctorId { get; set; }

        public int doctorsProfessionalism { get; set; }
        public int doctorsPoliteness { get; set; }

        public int doctorsTechnicality { get; set; }

        public int doctorsSkill { get; set; }

        public int doctorsKnowledge { get; set; }

        public int doctorsWorkingPace { get; set; }

        //for medical staff
        public int medicalStaffsProfessionalism { get; set; }
        public int medicalStaffsPoliteness { get; set; }
        public int medicalStaffsTechnicality { get; set; }
        public int medicalStaffsSkill { get; set; }
        public int medicalStaffsKnowledge { get; set; }
        public int medicalStaffsWorkingPace { get; set; }

        //for hospital

        public int hospitalEnvironment { get; set; }

        public int hospitalEquipment { get; set; }

        public int hospitalHygiene { get; set; }
        public int hospitalPrices { get; set; }
        public int hospitalWaitingTime { get; set; }

        public Survey() : base()
        {    
            
        }



        public Survey(int doctorId, int doctorsProfessionalism, int doctorsPoliteness, int doctorsTechnicality, int doctorsSkill, int doctorsKnowledge, int doctorsWorkingPace, int medicalStaffsProfessionalism, int medicalStaffsPoliteness, int medicalStaffsTechnicality, int medicalStaffsSkill, int medicalStaffsKnowledge, int medicalStaffsWorkingPace, int hospitalEnvironment, int hospitalEquipment, int hospitalHygiene, int hospitalPrices, int hospitalWaitingTime) : base()
        {
            this.doctorId = doctorId;
            this.doctorsProfessionalism = doctorsProfessionalism;
            this.doctorsPoliteness = doctorsPoliteness;
            this.doctorsTechnicality = doctorsTechnicality;
            this.doctorsSkill = doctorsSkill;
            this.doctorsKnowledge = doctorsKnowledge;
            this.doctorsWorkingPace = doctorsWorkingPace;
            this.medicalStaffsProfessionalism = medicalStaffsProfessionalism;
            this.medicalStaffsPoliteness = medicalStaffsPoliteness;
            this.medicalStaffsTechnicality = medicalStaffsTechnicality;
            this.medicalStaffsSkill = medicalStaffsSkill;
            this.medicalStaffsKnowledge = medicalStaffsKnowledge;
            this.medicalStaffsWorkingPace = medicalStaffsWorkingPace;
            this.hospitalEnvironment = hospitalEnvironment;
            this.hospitalEquipment = hospitalEquipment;
            this.hospitalHygiene = hospitalHygiene;
            this.hospitalPrices = hospitalPrices;
            this.hospitalWaitingTime = hospitalWaitingTime;
        }

        public Survey(int id, int doctorId, int doctorsProfessionalism, int doctorsPoliteness, int doctorsTechnicality, int doctorsSkill, int doctorsKnowledge, int doctorsWorkingPace, int medicalStaffsProfessionalism, int medicalStaffsPoliteness, int medicalStaffsTechnicality, int medicalStaffsSkill, int medicalStaffsKnowledge, int medicalStaffsWorkingPace, int hospitalEnvironment, int hospitalEquipment, int hospitalHygiene, int hospitalPrices, int hospitalWaitingTime) : base(id)
        {
            this.doctorId = doctorId;
            this.doctorsProfessionalism = doctorsProfessionalism;
            this.doctorsPoliteness = doctorsPoliteness;
            this.doctorsTechnicality = doctorsTechnicality;
            this.doctorsSkill = doctorsSkill;
            this.doctorsKnowledge = doctorsKnowledge;
            this.doctorsWorkingPace = doctorsWorkingPace;
            this.medicalStaffsProfessionalism = medicalStaffsProfessionalism;
            this.medicalStaffsPoliteness = medicalStaffsPoliteness;
            this.medicalStaffsTechnicality = medicalStaffsTechnicality;
            this.medicalStaffsSkill = medicalStaffsSkill;
            this.medicalStaffsKnowledge = medicalStaffsKnowledge;
            this.medicalStaffsWorkingPace = medicalStaffsWorkingPace;
            this.hospitalEnvironment = hospitalEnvironment;
            this.hospitalEquipment = hospitalEquipment;
            this.hospitalHygiene = hospitalHygiene;
            this.hospitalPrices = hospitalPrices;
            this.hospitalWaitingTime = hospitalWaitingTime;
        }
    }
}

using SearchMicroserviceApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchMicroserviceApi.Dtos
{
    public class MicroserviceReferralDto : Entity
    {
        public string medicine { get; set; }
        public string takeMedicineUntil { get; set; }
        public int quantityPerDay { get; set; }
        public string classify { get; set; }
        public string comment { get; set; }
        public int AppointmentId { get; set; }

        public MicroserviceReferralDto() : base() { }
        public MicroserviceReferralDto(int id, string medicine, string takeMedicineUntil, int quantityPerDay, string classify, string comment) : base(id)

        {
            this.medicine = medicine;
            this.takeMedicineUntil = takeMedicineUntil;
            this.quantityPerDay = quantityPerDay;
            this.classify = classify;
            this.comment = comment;

        }

        public MicroserviceReferralDto(int id, string medicine, string takeMedicineUntil, int quantityPerDay, string classify, string comment, int appointmentId) : base(id)

        {
            this.medicine = medicine;
            this.takeMedicineUntil = takeMedicineUntil;
            this.quantityPerDay = quantityPerDay;
            this.classify = classify;
            this.comment = comment;
            AppointmentId = appointmentId;
        }
    }
}

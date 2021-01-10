using SearchMicroserviceApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchMicroserviceApi.Dtos
{
    public class MicroserviceOperationReferralDto : Entity
    {
        public string Medicine { get; set; }
        public string TakeMedicineUntil { get; set; }
        public int QuantityPerDay { get; set; }
        public string Classify { get; set; }
        public string Comment { get; set; }
        public int OperationId { get; set; }

        public MicroserviceOperationReferralDto() : base() { }
        public MicroserviceOperationReferralDto(int id, string medicine, string takeMedicineUntil, int quantityPerDay, string classify, string comment) : base(id)
        {
            Medicine = medicine;
            TakeMedicineUntil = takeMedicineUntil;
            QuantityPerDay = quantityPerDay;
            Classify = classify;
            Comment = comment;
        }

        public MicroserviceOperationReferralDto(int id, string medicine, string takeMedicineUntil, int quantityPerDay, string classify, string comment, int appointmentId) : base(id)
        {
            Medicine = medicine;
            TakeMedicineUntil = takeMedicineUntil;
            QuantityPerDay = quantityPerDay;
            Classify = classify;
            Comment = comment;
            OperationId = appointmentId;
        }
    }
}

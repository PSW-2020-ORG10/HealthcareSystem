﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MedicineInformationApi.Model
{
    public class MedicineDescription
    {
        [Key]
        public String Name { get; set; }
        public String Description { get; set; }
        public int MedicineInformationId { get; set; }

        public MedicineDescription() { }
        public MedicineDescription(String name, String description)
        {
            Name = name;
            Description = description;
        }

        public MedicineDescription(String name, String description, int medicineInformationId)
        {
            Name = name;
            Description = description;
            MedicineInformationId = medicineInformationId;
        }
    }
}

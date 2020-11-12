/***********************************************************************
 * Module:  Renovation.cs
 * Author:  Luna
 * Purpose: Definition of the Class Hospital.Renovation
 ***********************************************************************/

using HealthClinic.BL.Model.Patient;
using System;

namespace HealthClinic.BL.Model.Hospital
{
    public class Renovation : Entity
    {
        public string room { get; set; }

        public string startDate { get; set; }
        public string endDate { get; set; }

        public Renovation(int id, string room, string startDate, string endDate) : base(id)
        {
            this.room = room;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public Renovation() : base()
        {

        }

    }
}
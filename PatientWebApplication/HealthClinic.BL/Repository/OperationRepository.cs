/***********************************************************************
 * Module:  OperationRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.OperationRepository
 ***********************************************************************/

using HCI_wireframe.Model.Doctor;
using HealthClinic.BL.Model.Doctor;
using System;
using System.Collections.Generic;

namespace HealthClinic.BL.Repository
{
    public class OperationRepository : GenericFileRepository<Operation>
   {
        public OperationRepository(string filePath) : base(filePath){ }

        public OperationRepository() : base() { }

    }
}
/***********************************************************************
 * Module:  OperationRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.OperationRepository
 ***********************************************************************/

using Class_diagram.Model.Doctor;
using HCI_wireframe.Model.Doctor;
using System;
using System.Collections.Generic;

namespace Class_diagram.Repository
{
   public class OperationRepository : GenericFileRepository<Operation>
   {
        public OperationRepository(string filePath) : base(filePath){ }

        public OperationRepository() : base() { }

    }
}
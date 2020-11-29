using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Doctor;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Adapters
{
    public class OperationAdapter
    {
        /// <summary>This method creates <c>OperationDto</c> from provided <paramref name="operation"/>.</summary>
        /// <param name="operation"><c>operation</c> is <c>Operatiion</c> that contains doctor's first name and surname, <c>OperationReferral</c> and <c>Date</c>.</param>
        /// <returns> Created <c>OperationDto</c>. </returns>
        public OperationDto OperationToOperationDto(Operation operation)
        {
            return new OperationDto(operation.Doctor.firstName + " " + operation.Doctor.secondName, operation.operationReferral, operation.Date);
        }

        /// <summary>This method creates List of <c>OperationDto</c> from provided <paramref name="operations"/>.</summary>
        /// <param name="operations"><c>operations</c> is List of <c>Operation</c>.</param>
        /// <returns> Created List of <c>OperationDto</c>. </returns>
        public List<OperationDto> ConvertOperationListToOperationDtoList(List<Operation> operations)
        {
            List<OperationDto> operationsDto = new List<OperationDto>();
            OperationAdapter adapter = new OperationAdapter();
            foreach (Operation operation in operations)
            {
                operationsDto.Add(adapter.OperationToOperationDto(operation));
            }
            return operationsDto;
        }
    }
}

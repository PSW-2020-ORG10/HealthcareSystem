using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Doctor;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Adapters
{
    public class OperationAdapter
    {
        public OperationDto OperationToOperationDto(Operation operation)
        {
            return new OperationDto(operation.Doctor.firstName + " " + operation.Doctor.secondName, operation.operationReferral, operation.Date);
        }

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

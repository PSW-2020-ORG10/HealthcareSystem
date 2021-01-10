using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroserviceApi.Dtos;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Adapters
{
    public static class MicroserviceShiftAdapter
    {
        public static MicroserviceShiftDto ShiftToMicroserviceShiftDto(Shift shift)
        {
            return new MicroserviceShiftDto(shift.Id, shift.StartTime, shift.EndTime);
        }

        public static List<MicroserviceShiftDto> ShiftListToMicroserviceShiftDtoList(List<Shift> shifts)
        {
            List<MicroserviceShiftDto> microserviceShiftDtos = new List<MicroserviceShiftDto>();
            foreach(Shift shift in shifts)
            {
                microserviceShiftDtos.Add(ShiftToMicroserviceShiftDto(shift));
            }
            return microserviceShiftDtos;
        }
    }
}

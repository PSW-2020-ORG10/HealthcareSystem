﻿using UrgentMedicineOrderApi.Model;
using UrgentMedicineOrderApi.Dto;

namespace UrgentMedicineOrderApi.Adapter
{
    public class UrgentMedicineOrderAdapter
    {
        public static UrgentMedicineOrder UrgentMedicineOrderDtoUrgentMedicineOrder(UrgentMedicineOrderDto dto)
        {
            return new UrgentMedicineOrder(dto.Name, dto.Quantity, dto.Pharmacy,dto.DateOfOrder);
        }

        public static UrgentMedicineOrderDto UrgentMedicineOrderToUrgentMedicineOrderDto(UrgentMedicineOrder order)
        {
            return new UrgentMedicineOrderDto(order.Name, order.Quantity, order.Pharmacy, order.DateOfOrder);
        }
    }
}
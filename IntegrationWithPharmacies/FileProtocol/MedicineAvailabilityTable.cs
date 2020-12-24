using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies.FileProtocol
{
    public class MedicineAvailabilityTable
    {
        public MedicineAvailabilityTable() { }
        public List<MedicineName> FormMedicineAvailability(string availability)
        {
            if (availability.Length > 5) return GetMedicineAvailabilityTable(availability);
            return null;
        }
        public List<MedicineName> GetMedicineAvailabilityTable(string availability)
        {
            List<MedicineName> medicines = new List<MedicineName>();
            String[] fileParts = availability.Split(";");
            if (fileParts.Length == 0) GetOnlyOnePharmacy(availability, medicines);
            else GetAllPharmacies(medicines, fileParts);
            return medicines;
        }
        public static void GetAllPharmacies(List<MedicineName> medicines, string[] fileParts)
        {
            for (int i = 0; i < fileParts.Length; i++)
            {
                String[] nameParts = fileParts[i].Split("_");
                AddMedicineToList(medicines, nameParts);
            }
        }

        public static void GetOnlyOnePharmacy(string availability, List<MedicineName> medicines)
        {
            String[] nameParts = availability.Split("_");
            AddMedicineToList(medicines, nameParts);
        }
        public static void AddMedicineToList(List<MedicineName> medicines, string[] nameParts)
        {
            medicines.Add(new MedicineName("Pharmacy: " + nameParts[0] + ", city: " + nameParts[1], nameParts[2]));
        }
    }
}

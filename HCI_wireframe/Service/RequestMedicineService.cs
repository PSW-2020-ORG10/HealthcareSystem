using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_diagram.Contoller;
using Class_diagram.Model.Hospital;
using Class_diagram.Repository;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.Repository;
namespace HCI_wireframe.Service
{
    class RequestMedicineService : bingPath, IService<Medicine>
    {
        public RoomRepository roomRepository;
        public RequestMedicineRepository medicineRepository;
        String path = bingPathToAppDir(@"JsonFiles\medicineRequests.json");
        String path2 = bingPathToAppDir(@"JsonFiles\room.json");

        public RequestMedicineService()
        {
            medicineRepository = new RequestMedicineRepository(path);
            roomRepository = new RoomRepository(path2);
        }
    
        public void New(Medicine medicine)
        {
            List<Room> listOfRooms = new List<Room>();
            listOfRooms = roomRepository.GetAll();


            foreach (Room room in listOfRooms)
            {
                if (room.TypeOfRoom.Equals("Magacin"))
                {
                    medicine.room.Add(room.TypeOfRoom);
                    room.medicine.Add(medicine.Name);
                    roomRepository.Update(room);
                }
            }

            medicineRepository.New(medicine);
        }
        public void Update(Medicine medicine)
        {
            medicineRepository.Update(medicine);
          
        }
        public void Remove(Medicine medicine)
        {
            medicineRepository.Delete(medicine.ID);
        }
       
      
        public List<Medicine> GetAll()
        {
            return medicineRepository.GetAll();
          
        }

        public Medicine GetByID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
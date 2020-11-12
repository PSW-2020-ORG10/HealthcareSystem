using System;
using System.Collections.Generic;
using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Repository;

namespace HealthClinic.CL.Service
{
    class RequestMedicineService : BingPath, IService<Medicine>
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

        private Boolean isRoomStorage(Room room)
        {
            if(room.typeOfRoom.Equals("Magacin"))
            {
                return true;
            }
            return false;
        }

        private void addMedicineIfRoomIsStorage(Medicine medicine, Room room)
        {
            if (isRoomStorage(room))
            {
                medicine.room.Add(new ModelRoom(room.typeOfRoom));
               
                room.medicine.Add(new ModelMedicine(medicine.name));
                roomRepository.Update(room);
                
            }
        }

        private void addMedicineToStorages(Medicine medicine)
        {
            List<Room> listOfRooms = new List<Room>();
            listOfRooms = roomRepository.GetAll();

            foreach (Room room in listOfRooms)
            {
                addMedicineIfRoomIsStorage(medicine, room);
            }
        }
    
        public void New(Medicine medicine)
        {
            addMedicineToStorages(medicine);
            medicineRepository.New(medicine);
        }

        public void Update(Medicine medicine)
        {
            medicineRepository.Update(medicine);
          
        }
        public void Remove(Medicine medicine)
        {
            medicineRepository.Delete(medicine.id);
        }
       
      
        public List<Medicine> GetAll()
        {
            return medicineRepository.GetAll();
          
        }

        public Medicine GetByid(int id)
        {
            return medicineRepository.GetByid(id);
        }
    }
}
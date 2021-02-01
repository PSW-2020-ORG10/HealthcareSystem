/***********************************************************************
 * Module:  Entity.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Repository.Entity
 ***********************************************************************/

namespace AppointmentMicroserviceApi.Model
{
    public class Entity
    {
        public Entity() { }
        public Entity(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
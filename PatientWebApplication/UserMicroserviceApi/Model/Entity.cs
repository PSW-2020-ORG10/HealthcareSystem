/***********************************************************************
 * Module:  Entity.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Repository.Entity
 ***********************************************************************/

namespace UserMicroserviceApi.Model
{
    public class Entity
    {
        public Entity() { }
        public Entity(int id)
        {
            this.id = id;
        }
        public int id { get; set; }
    }
}
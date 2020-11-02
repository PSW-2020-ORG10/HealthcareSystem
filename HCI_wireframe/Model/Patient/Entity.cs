/***********************************************************************
 * Module:  Entity.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Repository.Entity
 ***********************************************************************/

using System;
using System.Windows.Media.TextFormatting;

namespace Class_diagram.Model.Patient
{
    public class Entity
    {
        public Entity() { }
        public Entity(int id )
        {
            this.id = id;
        }
        public int id { get; set; }
    }
}
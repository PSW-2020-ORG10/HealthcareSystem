using Class_diagram.Model.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_wireframe.Model.Patient
{
    public class StringData : Entity
    {
        public string Data { get; set; }

        public StringData(string data)
        {
            Data = data;
        }

        public StringData(int id, string data) : base(id)
        {
            Data = data;
        }

        public StringData()
        {
            Data = "";
        }
    }
}

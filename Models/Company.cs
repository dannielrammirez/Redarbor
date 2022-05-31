using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIRedarbor.Models
{
    public class Company
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}

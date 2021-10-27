﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudUsingXamarin.Models
{
    class Employee
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return this.Name + "(" + this.Address + ")"; 
        }
    }
}

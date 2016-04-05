using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatApp.Models
{
    public class Room
    {
        public String Name { get; set; }
        public Room(string name)
        {
            this.Name = name;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatApp.Models
{
    public class RoomRepository
    {
        private List<Room> rooms;
        public RoomRepository()
        {
            rooms = new List<Room>();
            rooms.Add(new Room("Sci-fi"));
            rooms.Add(new Room("Action"));
            rooms.Add(new Room("Comedie"));
            rooms.Add(new Room("Adventure"));
            rooms.Add(new Room("Drama"));
            rooms.Add(new Room("Romantic"));
        }
        public List<Room> getAllRooms()
        {
            return this.rooms;
        }
    }
}
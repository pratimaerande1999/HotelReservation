using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Models
{
    public class guest
    {
        [Key]
        public int guest_Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public long phone_number { get; set; }
        public string email_id { get; set; }

    }
     public class Occupied_room
     {
        [Key]
         public int occupied_room_id { get; set; }
        public DateTime check_in_date { get; set; }
        public DateTime check_out_date { get; set; }
        public int room_id { get; set; }
        public int reservation_id { get; set; }
     }
    public class Admitance
    {
        [Key]
        public int admit_id { get; set; }
        public int guest_id { get; set; }
        public int occupied_room_id { get; set; }
    }
    public class Room_type
    {
        [Key]
        public int room_type_id { get; set; }
        public int room_type { get; set; }
        public int room_descrtion { get; set; }
        public int room_capacity { get; set; }
    }
}
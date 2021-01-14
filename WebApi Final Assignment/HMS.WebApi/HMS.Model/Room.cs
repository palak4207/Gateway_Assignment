using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public Nullable<int> RoomCategory { get; set; }
        public Nullable<double> RoomPrice { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public int HotelId { get; set; }
    }
}

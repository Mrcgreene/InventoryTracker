using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryTracking.Models
{
    public class StoreModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int StoreID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public StoreModel(string Name, string Address, string Phone, double Latitude, double Longitude)
        {
            this.Name = Name;
            this.Address = Address;
            this.Phone = Phone;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
    }
}
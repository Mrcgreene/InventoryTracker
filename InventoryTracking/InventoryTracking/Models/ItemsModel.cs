using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryTracking.Models
{
    public class ItemsModel
    {
        [Key]
        public int Id { get; set; }
        public int sku { get; set; }
        public string  name { get; set; }
        public int itemQuantity { get; set; }
        public double itemPrice { get; set; }
        public int storeID { get; set; }


        //public ItemsModel()
        //{

        //}

        //public ItemsModel(int Sku, string Name, int ItemQuantity, double ItemPrice)
        //{
        //    sku = Sku;
        //    name = Name;
        //    itemQuantity = ItemQuantity;
        //    itemPrice = ItemPrice;
        //}

       

    }

   
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_EntityLibrary
{
    
    public class Product
    {
        public int Id { get; private set; }
        public Category Category { get; private set; }
        public SubCategory SubCategory { get; private set; }
        public Brand Brand { get; private set; }
        public string Model { get; private set; }
        public string Desciption { get; private set; }
        public decimal Price { get; private set; }
        public int WarehouseQuantity { get; private set; }


        public Product(int id)
        {
            //load based on ID
        }

        public Product(int id, SubCategory subCategory, Brand brand, string model, string desciption, decimal price, int warehouseQuantity)
        {
            Id = id;
            SubCategory = subCategory;
            Brand = brand;
            Model = model;
            Desciption = desciption;
            Price = price;
            WarehouseQuantity = warehouseQuantity;
        }
    }
}

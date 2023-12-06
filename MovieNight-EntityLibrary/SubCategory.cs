using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_EntityLibrary
{
    public class SubCategory
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }


        public SubCategory(int id, Category category, string name)
        {
            Id = id;
            Category = category;
            Name = name;
        }
    }
}
